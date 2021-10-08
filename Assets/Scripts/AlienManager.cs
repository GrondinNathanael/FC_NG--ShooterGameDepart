using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienManager : MonoBehaviour
{
    [SerializeField] GameObject alienPrefab;

    [SerializeField] GameObject[] portals;
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
        if (totalSpawnedAliens < numberMaxAliens && spawnCooldown <= 0)
        {
            spawnCooldown = secondsBeforeSpawn;

            SpawnAlien();

            return;
        }

        spawnCooldown -= Time.deltaTime;
    }

    void SpawnAlien()
    {
        int portalIndex = Random.Range(0, portals.Length);

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
}