using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class AnswerSystem : MonoBehaviour
{
    public bool answer; 
    public int theAnswer; //手動輸入答案
    private int x; //目前答案
    public GameObject ThingsToSay;
    public GameObject ThingsToSay2; //跳出提示
    public GameObject hidethequestion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)) //通常是 no
        {
        x=1;
        hidethequestion.SetActive(false);
        ThingsToSay.SetActive(true);
        //ThingsToSay2.SetActive(false);
        Destroy(ThingsToSay2);
        }
        else if (Input.GetKeyDown(KeyCode.K)) //通常是 yes
        {
        x=2;    
        hidethequestion.SetActive(false);
        ThingsToSay2.SetActive(true);
        //ThingsToSay.SetActive(false);
        Destroy(ThingsToSay);
        }


          if(x == theAnswer)
          {
            Invoke("ChangeScene",5f);
          }   




    }

    void ChangeScene()
    {
        print(UnityEngine.SceneManagement.SceneManager.sceneCount);
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            Random.Range(0, UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings)
        );
    }
    
}
