using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    private const int NB_BULLET = 15;
    private GameObject[] projectiles = new GameObject[NB_BULLET];

    private const float BULLET_MAX_COOLDOWN = 0.2f;
    private float bulletCooldown = BULLET_MAX_COOLDOWN;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < NB_BULLET; i++)
        {
            projectiles[i] = Instantiate(bullet);
            projectiles[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(bulletCooldown < BULLET_MAX_COOLDOWN) bulletCooldown += Time.deltaTime;

        if (Input.GetButton("Fire1") && bulletCooldown >= BULLET_MAX_COOLDOWN)
        {
            bulletCooldown = 0;
            foreach (GameObject bullet in projectiles)
            {
                if(!bullet.activeSelf)
                {
                    bullet.SetActive(true);
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;
                    break;
                }
            }
        }
    }
}
