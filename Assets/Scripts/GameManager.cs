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
    [SerializeField] private Text gameOverText;
    [SerializeField] private Text winText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void changeHealth()
    {
        heartText.text = playerHp.ToString();
    }

    private void gameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }

    private void win()
    {
        winText.gameObject.SetActive(true);
    }
}
