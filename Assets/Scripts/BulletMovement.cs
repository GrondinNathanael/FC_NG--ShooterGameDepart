using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float velocity = 5f;
    [SerializeField] private int damage = 1;
    [SerializeField] private List<string> ignoredTriggers;

    [SerializeField] private bool isRocket = false;
    [SerializeField] private float defaultRocketRadius = 0.5f;
    [SerializeField] private float rocketExplosionRadius = 2f;

    SphereCollider bulletCollider;
    ParticleSystem explosionParticleSystem;

    GameObject shooter;

    private const float MAX_TTL = 3f;
    private float ttl = MAX_TTL;

    private bool isDying = false;
    private const float DYING_TIME = 0.1f;
    private float timeToDie = DYING_TIME;

    // Start is called before the first frame update
    void Start()
    {
        bulletCollider = GetComponent<SphereCollider>();

        if (isRocket) explosionParticleSystem = GetComponents<ParticleSystem>()[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            transform.Translate(Vector3.forward * velocity * Time.deltaTime);
            ttl -= Time.deltaTime;

            if (ttl <= 0)
            {
                resetBullet();
            }
        }

        if (isRocket && isDying)
        {
            if (timeToDie <= 0) resetBullet();

            else timeToDie -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!ignoredTriggers.Contains(other.tag))
        {
            if (isRocket && !isDying)
            {
                // On change la taille du collider pour simuler l'explosion et on commence un petit délai
                // pour s'assurer que les créatures aient le temps de prendre en compte sa nouvelle taille.
                bulletCollider.radius = rocketExplosionRadius;

                explosionParticleSystem.Play();

                isDying = true;
            }

            else if (!isDying) resetBullet();
        }
    }

    private void resetBullet()
    {
        gameObject.SetActive(false);
        ttl = MAX_TTL;

        if (isRocket)
        {
            bulletCollider.radius = defaultRocketRadius;

            isDying = false;
            timeToDie = DYING_TIME;
        }
    }

    public GameObject getShooter()
    {
        return shooter;
    }

    public void setShooter(GameObject newShooter)
    {
        shooter = newShooter;
    }

    public int getDamage()
    {
        return damage;
    }
}
