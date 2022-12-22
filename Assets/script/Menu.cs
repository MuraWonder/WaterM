using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{   public GameObject YesNo;
    // Start is called before the first frame update
    void Start()
    {
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void play()
    {
        SceneManager.LoadScene("Video01");
    }
    public void gallery()
    {
        SceneManager.LoadScene("Gallery");
    }
    public void Exit()
    {
        YesNo.SetActive(true);
        
    }
    public void Yes()
    {
        Application.Quit(); 
    }
    public void No()
    {
        YesNo.SetActive(false);
    }
     public void toSlevel()
    {
        SceneManager.LoadScene("SLevel");
    }
     public void Level01()
    {
        SceneManager.LoadScene("01");
    }
      public void Level02()
    {
        SceneManager.LoadScene("Talk02");
    }
       public void Level03()
    {
        SceneManager.LoadScene("03");
    }
       public void backtoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Resume()
    {
      Time.timeScale = 1f;
    }

}
