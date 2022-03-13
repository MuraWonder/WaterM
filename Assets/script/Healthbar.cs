using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public float MAX_HEALTH;
    public float health;

    public Image bar;
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(gameObject);
        health = MAX_HEALTH;

       //Invoke("ChangeScene",5f);

    }

    // void ChangeScene(){
    //     print(UnityEngine.SceneManagement.SceneManager.sceneCount);
    //     UnityEngine.SceneManagement.SceneManager.LoadScene(
    //         Random.Range(0, UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings)
    //     );
    // }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = Player.health/Player.s_maxHealth;
    }
}
