using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    // Start is called before the first frame update
    //作弊按鈕
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.L))
            {
                SceneManager.LoadScene("End");
            }
        if (Input.GetKey(KeyCode.K))
            {
                SceneManager.LoadScene("End2");
            }
    }
}
