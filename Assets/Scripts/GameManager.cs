using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text heartText;
    [SerializeField] private Text rocketsText;
    [SerializeField] private Text multishotText;
    [SerializeField] private Text gameOverText;
    [SerializeField] private Text winText;

    private int multishotTTL = 0;
    private int nbRocket = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeHealth(int playerHp)
    {
        heartText.text = playerHp.ToString();
    }

    public void changeRocketsText(int quanity)
    {
        rocketsText.text = quanity.ToString();
    }

    public void changeMultishotText(int seconds)
    {
        multishotText.text = seconds.ToString();
    }

    public void gameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }

    public void win()
    {
        winText.gameObject.SetActive(true);
    }
}
