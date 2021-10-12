using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] GameObject alienPrefab;

    [SerializeField] List<GameObject> portals;
    [SerializeField] float secondsBeforeSpawn = 3;

    [SerializeField] int numberAliensAtOneTime = 20;
    [SerializeField] int numberMaxAliens = 500;

    private float spawnCooldown;
    private GameObject[] aliens;
    private int totalSpawnedAliens = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnCooldown = secondsBeforeSpawn;

        aliens = new GameObject[numberAliensAtOneTime];

        for (int i = 0; i < numberAliensAtOneTime; i++)
        {
            aliens[i] = Instantiate(alienPrefab);
            aliens[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(areAllEnemiesDead())
        {
            gameManager.win();
        }

        if (totalSpawnedAliens < numberMaxAliens && spawnCooldown <= 0)
        {
            if(portals.Count > 0)
            {
                spawnCooldown = secondsBeforeSpawn;

                SpawnAlien();

                return;
            }
        }

        for (int i = 0; i < portals.Count; i++)
        {
            if (!portals[i].gameObject.activeSelf) portals.RemoveAt(i);
        }

        spawnCooldown -= Time.deltaTime;
    }

    void SpawnAlien()
    {
        int portalIndex = Random.Range(0, portals.Count);

        Vector3 spawnPosition = portals[portalIndex].transform.position;

        int nextAlienIndex = getNextUnactivatedAlienIndex();

        if (nextAlienIndex >= 0)
        {
            aliens[nextAlienIndex].transform.position = spawnPosition;

            aliens[nextAlienIndex].SetActive(true);

            totalSpawnedAliens++;
        }
    }

    int getNextUnactivatedAlienIndex()
    {
        for (int i = 0; i < numberAliensAtOneTime; i++)
        {
            if (!aliens[i].activeSelf) return i;
        }

        return -1;
    }

    public bool areAllEnemiesDead()
    {
        if(portals.Count > 0) return false;

        foreach (GameObject alien in aliens)
        {
            if (alien.activeSelf)
            {
                return false;
            }
        }

        return true;
    }
}
