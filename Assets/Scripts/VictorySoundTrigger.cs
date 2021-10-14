using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictorySoundTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource victorySound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playVictorySound()
    {
        victorySound.PlayOneShot(victorySound.clip);
    }
}
