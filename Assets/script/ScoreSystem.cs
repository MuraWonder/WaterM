using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{   public GameObject scoreText;
    public GameObject collectText;
    public GameObject GOscoreText;
    public static int theScore;
    public static int theCollect;
    
    // Start is called before the first frame update
   void Update()
    {
        scoreText.GetComponent<Text>().text = "SCORE:" + theScore;
        collectText.GetComponent<Text>().text = "x "+ theCollect;
        GOscoreText.GetComponent<Text>().text = "SCORE:" + theScore;
    }
}
