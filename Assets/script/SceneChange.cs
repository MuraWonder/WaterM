using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public VideoPlayer vPlayer;

    // Start is called before the first frame update
    void Start()
    {
        vPlayer.loopPointReached += EndReached;
        vPlayer.Play();
    }
    

    void EndReached(VideoPlayer vPlayer)
    {
        SceneManager.LoadScene("Menu");
    }
}

