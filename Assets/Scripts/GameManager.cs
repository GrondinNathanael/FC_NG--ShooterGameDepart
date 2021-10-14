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
    [SerializeField] private VictorySoundTrigger victoryTigger;

    private int multishotTTL = 0;
    private int nbRocket = 0;
    private bool isWinCalled = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Submit"))
        {
            Application.Quit();
        }
    }

    public void changeHealth(int playerHp)
    {
        heartText.text = playerHp.ToString();
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
        if (isWinCalled) return;
        winText.gameObject.SetActive(true);
        victoryTigger.playVictorySound();
        isWinCalled = true;
    }

    public void PlayClipAt(AudioClip clip, Vector3 pos)
    {
        GameObject tempGO = new GameObject("TempAudio");
        tempGO.transform.position = pos;
        AudioSource aSource = tempGO.AddComponent<AudioSource>();
        aSource.clip = clip;

        aSource.PlayOneShot(clip);
        Destroy(tempGO, clip.length);
    }
}
