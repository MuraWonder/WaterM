using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
public class SceneHandler : MonoBehaviour
{
    [SerializeField] RectTransform Fader;
    // Start is called before the first frame update
    public GameObject VideoPanelStart;
    public VideoPlayer DvPlayerStart;
    private void Start()
    {
        Fader.gameObject.SetActive(true);
        LeanTween.scale(Fader,new Vector3(1,1,1),0);
        LeanTween.scale(Fader,Vector3.zero,1.5f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() => {
        Fader.gameObject.SetActive(false);
        });
        DvPlayerStart.loopPointReached += EndReached3;
    }

    public void OpenVideo01Scene()
    {
        Fader.gameObject.SetActive(true);
        LeanTween.scale(Fader,Vector3.zero,0f);
        LeanTween.scale(Fader,new Vector3(1,1,1),0.5f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() => {
            SceneManager.LoadScene(2);
        });
    }

    public void Open01Scene()
    {
        Fader.gameObject.SetActive(true);
        LeanTween.scale(Fader,Vector3.zero,0f);
        LeanTween.scale(Fader,new Vector3(1,1,1),0.5f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() => {
            Invoke("ChangeScene",0.5f);
            
        });
    }
    void ChangeScene()  //目標
    {
        SceneManager.LoadScene("01");
    }
    void EndReached3(VideoPlayer DvPlayerStart)
    {   VideoPanelStart.SetActive(false);
        SceneManager.LoadScene("01");
    }
}