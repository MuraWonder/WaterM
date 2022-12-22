using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;



public class GameOverScreen : MonoBehaviour
{  public bool isblack = false;
   [Header("出現GG時會隱藏的UI")]
   public GameObject UI;
   public GameObject little;
   public GameObject Emoji;
   public GameObject YesNoIngame;
   [SerializeField]
   public GameObject VideoPanel;
   public VideoPlayer DvPlayer;
   [SerializeField]
   public int level; //選關卡
    // Start is called before the first frame update
  void Start(){
      
    
    Resume();
    }
  void Update(){
      
      if(isblack == true){
          Debug.Log("true");
          //Pause();
          UI.SetActive(true);
          little.SetActive(false);
          Emoji.SetActive(false);
      }
      if(isblack == false)
      {   UI.SetActive(false);
          little.SetActive(true);
          Emoji.SetActive(true);
        
          //Resume();
      }
      
  }
  public void Setup(){
      
      UI.SetActive(true);
      isblack=true;
      Pause();
      
      
  }
  public void Resume()
  {
      Time.timeScale = 1f;
  }
  public void Pause()
  {
      Time.timeScale = 0f;
  }
  public void RetryButton()
  {   isblack = false;
      Debug.Log("false");
      
      ScoreSystem.theScore = 0;
      ScoreSystem.theCollect = 0;
      Resume();
      if(level == 1){
      UnityEngine.SceneManagement.SceneManager.LoadScene("01");
      }
      if(level == 2){
      UnityEngine.SceneManagement.SceneManager.LoadScene("02");
      }
      if(level == 3){
      UnityEngine.SceneManagement.SceneManager.LoadScene("03");
      }
      //gameObject.SetActive(false);
      
      
  }
   public void MainButton()
  {   isblack = false;
      UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
      ScoreSystem.theScore = 0;
      ScoreSystem.theCollect = 0;
      //gameObject.SetActive(false);
        
  }

   public void Exit()
    {   
        YesNoIngame.SetActive(true);
        Pause();
    }

      public void Yes()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        //Application.Quit(); 
    }
    public void No()
    {   
        YesNoIngame.SetActive(false);
        Resume();
    }
    public void DvideoFirst()
    {
     VideoPanel.SetActive(true);
     DvPlayer.loopPointReached += EndReached2;
     DvPlayer.Play();
     Pause();
     
    }
    void EndReached2(VideoPlayer DvPlayer)
    {   VideoPanel.SetActive(false);
        isblack=true;
    }
 
}
