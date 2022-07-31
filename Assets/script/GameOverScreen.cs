using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameOverScreen : MonoBehaviour
{  public bool isblack = false;
   public GameObject UI;
   public GameObject little;
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
      }
      if(isblack == false)
      {   UI.SetActive(false);
          little.SetActive(true);
        
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
      UnityEngine.SceneManagement.SceneManager.LoadScene("01");
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
        Application.Quit(); 
    }
 
}
