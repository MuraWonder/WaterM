using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTalk : MonoBehaviour
{
    [SerializeField] RectTransform Fader;
    // Start is called before the first frame update
    private void Start()
    {
        Fader.gameObject.SetActive(true);
        LeanTween.scale(Fader,new Vector3(1,1,1),0);
        LeanTween.scale(Fader,Vector3.zero,1.5f).setEase(LeanTweenType.easeOutExpo).setOnComplete(() => {
            Fader.gameObject.SetActive(false);
        });
    }

    public void OpenEndScene()
    {
        Fader.gameObject.SetActive(true);
        LeanTween.scale(Fader,Vector3.zero,0f);
        LeanTween.scale(Fader,new Vector3(1,1,1),0.5f).setEase(LeanTweenType.easeOutExpo).setOnComplete(() => {
            SceneManager.LoadScene(4);
        });
    }

    public void OpenTalk01Scene()
    {
        Fader.gameObject.SetActive(true);
        LeanTween.scale(Fader,Vector3.zero,0f);
        LeanTween.scale(Fader,new Vector3(1,1,1),0.5f).setEase(LeanTweenType.easeOutExpo).setOnComplete(() => {
            Invoke("ChangeScene",0.8f);
        });
    }
    void ChangeScene()
    {
        SceneManager.LoadScene(5);
    }
}

