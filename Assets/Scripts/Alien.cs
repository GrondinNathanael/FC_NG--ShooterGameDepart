using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Alien : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Rigidbody alienRigidbody;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        alienRigidbody = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");

        navMeshAgent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        // On active le navMeshAgent quand on touche au sol.
        if (!navMeshAgent.enabled && collision.gameObject.CompareTag("Terrain"))
        {
            navMeshAgent.enabled = true;
            navMeshAgent.SetDestination(player.transform.position);
        }
    }
}
