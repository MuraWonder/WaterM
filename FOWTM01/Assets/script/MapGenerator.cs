using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject barrierPrefab;
    public int intervalNum;  // 數量
    public float interval;  // 單位長度
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < intervalNum; ++i)
        {
            if (Random.Range(0f, 1f) > .7f)
            {
                GameObject g = Instantiate(barrierPrefab, transform);
                g.transform.localPosition = new Vector3(i * interval, 0, 0);
                ++i;
            }
        }

        // Invoke("ChangeScene", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    void ChangeScene()
    {
        //        UnityEngine.SceneManagement.SceneManager.LoadScene("00 1");
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            Random.Range(0, UnityEngine.SceneManagement.SceneManager.sceneCount - 1)
        );

    }
}
