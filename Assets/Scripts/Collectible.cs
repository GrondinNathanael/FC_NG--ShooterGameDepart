using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] collectibleTypes type;
    [SerializeField] float collectValue;

    private enum collectibleTypes { Ammo, Armor, Health }

    private CollectibleManager collectibleManager;
    private PlayerShoot playerShoot;
    private HealthManager playerHealthManager;

    // Start is called before the first frame update
    void Start()
    {
        collectibleManager = GameObject.Find("GameManager").GetComponent<CollectibleManager>();
        playerShoot = GameObject.Find("BulletSpawn").GetComponent<PlayerShoot>();
        playerHealthManager = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnCollect();
        }
    }

    private void OnCollect()
    {
        collectibleManager.addAvaibleCollectible(gameObject);

        switch (type)
        {
            case collectibleTypes.Ammo:
                playerShoot.gainTripleBullets(collectValue);
                break;

            case collectibleTypes.Armor:
                break;

            case collectibleTypes.Health:
                playerHealthManager.gainHealth((int)collectValue);
                break;
        }
    }

}
