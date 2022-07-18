using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndCountScore : MonoBehaviour
{   public Text ScoreEND;
    //public Text highScoreEND;
    public Text CollectEND;
    //public Text highCollectEND;

    // Start is called before the first frame update
    void Start()
    {
        ScoreEND.text = "SCORE:" + ScoreSystem.theScore.ToString();
        CollectEND.text = "x " + ScoreSystem.theCollect.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //if (ScoreSystem.theCollect>highCollectEND)
        {
            //highCollectEND.ToString() = ScoreSystem.theCollect;
        }
    }
}
