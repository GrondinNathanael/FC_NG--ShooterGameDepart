using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
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
        maxHealthPoints -= points;
    }

    void die()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            looseHealth();

            if (maxHealthPoints <= 0)
            {
                die();
            }
        }

        else if (collision.gameObject.tag == "Player")
        {
            die();
        }
        Debug.Log("Entered coll");
    }

    private void OnEnable()
    {
        healthPoints = maxHealthPoints;
    }
}
