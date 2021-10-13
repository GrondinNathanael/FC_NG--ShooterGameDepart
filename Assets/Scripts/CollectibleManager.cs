using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    private const float COLLECTIBLE_HEIGHT = 5;

    [SerializeField] private GameObject[] collectiblePrefabs;
    [SerializeField] private int numberOfEachCollectible = 3;
    [SerializeField] private int percentageOfSpawnChances = 15;

    private GameObject[] collectibles;
    private List<GameObject> avaibleCollectibles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        collectibles = new GameObject[collectiblePrefabs.Length * numberOfEachCollectible];

        for (int i = 0; i < collectiblePrefabs.Length; i++)
        {
            for (int j = 0; j < numberOfEachCollectible; j++)
            {
                int newIndex = i * numberOfEachCollectible + j;

                collectibles[newIndex] = Instantiate(collectiblePrefabs[i]);

                avaibleCollectibles.Add(collectibles[newIndex]);

                collectibles[newIndex].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void handleSpawnCollectible(Vector3 position)
    {
        if (Random.Range(1, 100) < percentageOfSpawnChances)
        {
            spawnCollectible(position);
        }
    }

    public void addAvaibleCollectible(GameObject collectible)
    {
        avaibleCollectibles.Add(collectible);
    }

    private void spawnCollectible(Vector3 position)
    {
        if (avaibleCollectibles.Count > 0)
        {
            int randomIndex = Random.Range(0, avaibleCollectibles.Count);

            avaibleCollectibles[randomIndex].transform.position = new Vector3(position.x, COLLECTIBLE_HEIGHT, position.z);

            avaibleCollectibles[randomIndex].SetActive(true);

            avaibleCollectibles.RemoveAt(randomIndex);
        }
    }
}
