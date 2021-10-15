using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictorySoundTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource victorySound;

    private const float TIME_TO_PAUSE = 3f;
    private float timeLeft = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            if(timeLeft <= 0)
            {
                music.Play();
            }
        }
    }

    public void playVictorySound()
    {
        music.Pause();
        victorySound.PlayOneShot(victorySound.clip);
        timeLeft = TIME_TO_PAUSE;
    }
}
