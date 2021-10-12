using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int multishotTTL = 0;
    private int nbRocket = 0;
    [SerializeField] private float playerHp;
    [SerializeField] private Text heartText;
    [SerializeField] private Text rocketsText;
    [SerializeField] private Text multishotText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
