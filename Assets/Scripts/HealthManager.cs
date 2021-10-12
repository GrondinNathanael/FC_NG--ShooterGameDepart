using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private int maxHealthPoints = 1;

    private int healthPoints;
    private int fallingVelocity = -1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void looseHealth(int points = 1)
    {
        healthPoints -= points;
    }

    void gainHealth(int points = 1)
    {
        healthPoints += points;
    }

    void die()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            looseHealth();

            if (healthPoints <= 0)
            {
                die();
            }
        }
        if (other.gameObject.CompareTag("Enemy") && gameObject.CompareTag("Player"))
        {
            if(gameObject.GetComponent<CharacterController>().velocity.y > fallingVelocity)
            {
                looseHealth();
                gameManager.changeHealth(healthPoints);
                if (healthPoints <= 0)
                {
                    die();
                    gameManager.gameOver();
                }
            }
        }
    }

    private void OnEnable()
    {
        healthPoints = maxHealthPoints;
    }
}
