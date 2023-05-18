using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTalk3 : MonoBehaviour
{
    [SerializeField] RectTransform Fader;
    // Start is called before the first frame update
    private void Start()
    {
        Fader.gameObject.SetActive(true);
        LeanTween.scale(Fader,new Vector3(1,1,1),0);
        LeanTween.scale(Fader,Vector3.zero,1.5f).setEase(LeanTweenType.easeOutExpo).setOnComplete(() => {
            Fader.gameObject.SetActive(false);
        });
    }

    public void OpenEndScene()
    {
        Fader.gameObject.SetActive(true);
        LeanTween.scale(Fader,Vector3.zero,0f);
        LeanTween.scale(Fader,new Vector3(1,1,1),0.5f).setEase(LeanTweenType.easeOutExpo).setOnComplete(() => {
            SceneManager.LoadScene(4);
        });
    }

    public void OpenTalk03Scene()
    {
        Fader.gameObject.SetActive(true);
        LeanTween.scale(Fader,Vector3.zero,0f);
        LeanTween.scale(Fader,new Vector3(1,1,1),0.5f).setEase(LeanTweenType.easeOutExpo).setOnComplete(() => {
            Invoke("ChangeScene",0.8f);
        });
    }
    
    public void RetryButton()
  {   
      ScoreSystem.theScore = 0;
      ScoreSystem.theCollect = 0;
      Time.timeScale = 1f;
      UnityEngine.SceneManagement.SceneManager.LoadScene("03");
      
  }

    void ChangeScene() 
    {   //下一個
        SceneManager.LoadScene("Talk03E");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
      public void SkipTo03()
    {   //去第二關
        SceneManager.LoadScene("03");
    }
}

