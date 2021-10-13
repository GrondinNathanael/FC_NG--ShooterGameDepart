using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float velocity = 5f;

    private const float MAX_TTL = 3f;
    private float ttl = MAX_TTL;

    // Start is called before the first frame update
    void Start()
    {

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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.activeSelf && !other.CompareTag("Collectible"))
        {
            resetBullet();
        }
    }

    private void resetBullet()
    {
        gameObject.SetActive(false);
        ttl = MAX_TTL;
    }
}
