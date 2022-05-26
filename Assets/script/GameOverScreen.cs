using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameOverScreen : MonoBehaviour
{
    // Start is called before the first frame update
  void Update(){
      
  }
  public void Setup(){
      
      gameObject.SetActive(true);
      
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
  {   
      UnityEngine.SceneManagement.SceneManager.LoadScene("01");
  }
   public void MainButton()
  {   
      UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
  }
}
