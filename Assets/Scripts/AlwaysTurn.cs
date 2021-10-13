using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysTurn : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 50;
    [SerializeField] bool counterclockWise = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float rotationAmount = Time.deltaTime * rotationSpeed;
        if (counterclockWise) rotationAmount *= -1;

        gameObject.transform.Rotate(0, rotationAmount, 0);
    }
}
