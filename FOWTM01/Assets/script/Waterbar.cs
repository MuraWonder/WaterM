using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waterbar : MonoBehaviour
{   public float EMT_HEALTH;
    public float health2;

    public Image bar;
    // Start is called before the first frame update
    void Start()
    {
        health2 = EMT_HEALTH;
    }

    // Update is called once per frame
    void Update()
    {
       
     bar.fillAmount =1- Player.health2/Player.s_maxHealth2;
     
    
    }

    void ChangeScene(){
        print(UnityEngine.SceneManagement.SceneManager.sceneCount);
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            Random.Range(2, UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings)
        );
    }
}
