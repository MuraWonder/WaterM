using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sofar : MonoBehaviour
{   public Slider sofarSlider;
    public float gameTime;
    private bool stopTimer;
    // Start is called before the first frame update
    void Start()
    {
        
        sofarSlider.maxValue = gameTime;
        sofarSlider.value = gameTime;
    }

    // Update is called once per frame
    void Update()
    {
        float time = gameTime + Time.time;
        //sofarSlider.Value.Lerp(sofarSlider.minValue,sofarSlider.maxValue)
    }
}
