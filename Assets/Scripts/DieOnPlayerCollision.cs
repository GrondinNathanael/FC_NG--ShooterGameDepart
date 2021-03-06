using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnPlayerCollision : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioClip deathSound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            die();
        }
    }

    private void die()
    {
        gameManager.PlayClipAt(deathSound, transform.position);
        gameObject.SetActive(false);
    }
}
