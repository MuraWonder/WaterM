using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{   public GameObject YesNo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void play()
    {
        SceneManager.LoadScene("Video01");
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
}
