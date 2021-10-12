using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float maxHealthPoints = 1;

    private float healthPoints;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void looseHealth(float points = 1)
    {
        healthPoints -= points;
    }

    void die()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            looseHealth();

            if (healthPoints <= 0)
            {
                die();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGERED");

        if (other.gameObject.CompareTag("Bullet") || other.gameObject.tag == "Bullet")
        {
            Debug.Log("TRIGGERED W/ BULLET");
            looseHealth();

            if (healthPoints <= 0)
            {
                die();
            }
        }
    }

    private void OnEnable()
    {
        healthPoints = maxHealthPoints;
    }
}
