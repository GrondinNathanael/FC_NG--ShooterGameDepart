using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private int maxHealthPoints = 1;
    [SerializeField] private float maxInvincibilityCooldown = 2;

    private int healthPoints;
    private float invincibilityCooldown = 0;
    private int fallingVelocity = -1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (invincibilityCooldown > 0) invincibilityCooldown -= Time.deltaTime;
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

        if (this.gameObject.CompareTag("Enemy")) this.gameObject.GetComponent<Alien>()?.OnDeath();
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
            if(gameObject.GetComponent<CharacterController>().velocity.y > fallingVelocity && invincibilityCooldown <= 0)
            {
                invincibilityCooldown = maxInvincibilityCooldown;
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
