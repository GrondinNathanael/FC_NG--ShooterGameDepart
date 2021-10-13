using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 50;
    CollectibleManager collectibleManager;

    // Start is called before the first frame update
    void Start()
    {
        collectibleManager = GameObject.Find("GameManager").GetComponent<CollectibleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, Time.deltaTime * rotationSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collectibleManager.addAvaibleCollectible(gameObject);
        }
    }
}
