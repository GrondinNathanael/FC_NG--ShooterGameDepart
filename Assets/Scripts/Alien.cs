using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Alien : MonoBehaviour
{
    private CollectibleManager collectibleManager;
    private NavMeshAgent navMeshAgent;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        collectibleManager = GameObject.Find("GameManager").GetComponent<CollectibleManager>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

        navMeshAgent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.enabled) navMeshAgent.SetDestination(player.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        // On active le navMeshAgent quand on touche au sol.
        if (!navMeshAgent.enabled && other.gameObject.CompareTag("Terrain"))
        {
            navMeshAgent.enabled = true;
        }
    }

    public void OnDeath()
    {
        collectibleManager.handleSpawnCollectible(transform.position);
    }
}
