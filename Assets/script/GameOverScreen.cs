using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameOverScreen : MonoBehaviour
{  public bool isblack = false;
    // Start is called before the first frame update
  void Start(){
    Resume();
    }
  void Update(){
      if(isblack == true){
          Debug.Log("true");
          Pause();
      }
      if(isblack == false)
      {   
          Resume();
      }
      
  }
  public void Setup(){
      
      gameObject.SetActive(true);
      isblack=true;
      
      
  }
  void Resume()
  {
      Time.timeScale = 1f;
  }
  void Pause()
  {
      Time.timeScale = 0f;
  }
  public void RetryButton()
  {   isblack = false;
      Debug.Log("false");
      UnityEngine.SceneManagement.SceneManager.LoadScene("01");
      ScoreSystem.theScore = 0;
      ScoreSystem.theCollect = 0;
      
      
  }
   public void MainButton()
  {   isblack = false;
      UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
      ScoreSystem.theScore = 0;
      ScoreSystem.theCollect = 0;
      
      
  }
 
}
