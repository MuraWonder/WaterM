using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSound : MonoBehaviour
{     // Start is called before the first frame update

    public AudioSource collectSound;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
          if(other.gameObject.tag=="Plustime")
        {
            collectSound.Play();
            ScoreSystem.theScore += 100;
        }
        
        
    }
}
