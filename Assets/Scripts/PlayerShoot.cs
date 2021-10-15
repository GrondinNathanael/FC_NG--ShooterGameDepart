using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject rocket;
    [SerializeField] private float tripleBulletsAngle = 45;

    private const int NB_BULLET = 50;
    private GameObject[] bullets = new GameObject[NB_BULLET];
    private const float BULLET_MAX_COOLDOWN = 0.2f;
    private float bulletCooldown = BULLET_MAX_COOLDOWN;

    private const int NB_ROCKET = 50;
    private GameObject[] rockets = new GameObject[NB_ROCKET];
    private const float ROCKET_MAX_COOLDOWN = 1f;
    private float rocketCooldown = ROCKET_MAX_COOLDOWN;

    private int nbRockets = 0;
    private float tripleBulletsTime = 0;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        for (int i = 0; i < NB_BULLET; i++)
        {
            bullets[i] = Instantiate(bullet);
            bullets[i].SetActive(false);
        }

        for (int i = 0; i < NB_ROCKET; i++)
        {
            rockets[i] = Instantiate(rocket);
            rockets[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletCooldown < BULLET_MAX_COOLDOWN) bulletCooldown += Time.deltaTime;
        if (rocketCooldown < ROCKET_MAX_COOLDOWN) rocketCooldown += Time.deltaTime;

        handleTripleBulletsTime();

        if (Input.GetButton("Fire1") && bulletCooldown >= BULLET_MAX_COOLDOWN)
        {
            bulletCooldown = 0;

            if (tripleBulletsTime > 0) shootTripleBullet();
            else shootBullet();
        }

        else if (Input.GetButton("Fire2") && rocketCooldown >= ROCKET_MAX_COOLDOWN && nbRockets > 0)
        {
            rocketCooldown = 0;

            shootRocket();

            nbRockets--;
            gameManager.changeRocketsText(nbRockets);
        }
    }

    private void shootBullet(float angleModification = 0)
    {
        foreach (GameObject bullet in bullets)
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

                bullet.GetComponent<BulletMovement>().setShooter(transform.parent.gameObject);

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

    private void shootRocket()
    {
        foreach (GameObject rocket in rockets)
        {
            if (!rocket.activeSelf)
            {
                rocket.transform.position = transform.position;
                rocket.transform.rotation = transform.rotation;

                rocket.GetComponent<BulletMovement>().setShooter(transform.parent.gameObject);

                rocket.SetActive(true);
                break;
            }
        }
    }

    public void gainTripleBullets(float shootingSeconds)
    {
        this.tripleBulletsTime += shootingSeconds;
        gameManager.changeMultishotText((int)tripleBulletsTime);
    }
    public void gainRockets(int quantity)
    {
        nbRockets += quantity;
        gameManager.changeRocketsText(nbRockets);
    }
}
