using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text text;
    static float time;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {   DontDestroyOnLoad(gameObject);
        time += Time.deltaTime;
        text.text = time.ToString("f2");
    }
}
