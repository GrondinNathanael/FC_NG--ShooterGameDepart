using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float tripleBulletsAngle = 45;

    private const int NB_BULLET = 50;
    private GameObject[] projectiles = new GameObject[NB_BULLET];

    private const float BULLET_MAX_COOLDOWN = 0.2f;
    private float bulletCooldown = BULLET_MAX_COOLDOWN;

    private float tripleBulletsTime = 0;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        for (int i = 0; i < NB_BULLET; i++)
        {
            projectiles[i] = Instantiate(bullet);
            projectiles[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletCooldown < BULLET_MAX_COOLDOWN) bulletCooldown += Time.deltaTime;

        handleTripleBulletsTime();

        if (Input.GetButton("Fire1") && bulletCooldown >= BULLET_MAX_COOLDOWN)
        {
            bulletCooldown = 0;

            if (tripleBulletsTime > 0) shootTripleBullet();
            else shootBullet();
        }
    }

    private void shootBullet(float angleModification = 0)
    {
        foreach (GameObject bullet in projectiles)
        {
            if (!bullet.activeSelf)
            {
                bullet.SetActive(true);

                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;

                if (angleModification != 0)
                {
                    bullet.transform.Rotate(0, angleModification, 0);
                }

                break;
            }
        }
    }

    private void shootTripleBullet()
    {

        shootBullet(0); // Center Bullet

        shootBullet(-tripleBulletsAngle); // Left Bullet

        shootBullet(tripleBulletsAngle); // Right Bullet
    }

    private void handleTripleBulletsTime()
    {
        if (Input.GetButton("Fire1") && tripleBulletsTime > 0)
        {
            tripleBulletsTime -= Time.deltaTime;
            gameManager.changeMultishotText((int)tripleBulletsTime);
        }

        else if (tripleBulletsTime < 0) tripleBulletsTime = 0;
    }

    public void gainTripleBullets(float shootingSeconds)
    {
        this.tripleBulletsTime += shootingSeconds;
        gameManager.changeMultishotText((int)tripleBulletsTime);
    }
}
