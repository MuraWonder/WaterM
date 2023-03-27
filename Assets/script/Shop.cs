using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{   public Text ShopScoreText;
    public Animator Unlockanim;
    public Animator Unlockanim2;
    public Animator Unlockanim3;
    public Animator Unlockanim4;
    public GameObject min;
    public GameObject clo;
    public GameObject min2;
    public GameObject clo2;
    public GameObject min3;
    public GameObject clo3;
    public GameObject min4;
    public GameObject clo4;
    public GameObject p1; //cg視窗1
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject CGW; //大視窗
    int ShopScore =0;
    //public Text ShopCollect;
    // Start is called before the first frame update
    void Start()
    {   ShopScore = PlayerPrefs.GetInt("此關分數");
        ShopScoreText.text ="TOTLE_SCORE:  " + ShopScore.ToString();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(ShopScore >= 3900){

        //     Unlockanim.Play("Unlock");
        // }
        // else{
        //     Unlockanim.Play("New State");
        // }
    
    }
     public void clickUn(){ 
        if(ShopScore >= 0){  //第一章圖
            //animation["Unlock"].wrapMode = WrapMode.Once;
            Unlockanim.Play("Unlock");
            min.SetActive(true); //大視窗出現
            clo.SetActive(true); //小視窗不見
            //Unlockanim.SetActive(false);
            //Destroy(Unlockanim);
        }
    }
     public void clickUn2(){ 
        if(ShopScore >= 0){

            Unlockanim2.Play("Unlock2");
            min2.SetActive(true); //大視窗出現
            clo2.SetActive(true); //小視窗不見
        }
    }
     public void clickUn3(){ 
        if(ShopScore >= 0){

            Unlockanim3.Play("Unlock3");
            min3.SetActive(true); //大視窗出現
            clo3.SetActive(true); //小視窗不見
        }
    }
     public void clickUn4(){ 
        if(ShopScore >= 0){

            Unlockanim4.Play("Unlock4");
            min4.SetActive(true); //大視窗出現
            clo4.SetActive(true); //小視窗不見
        }
    }
    public void clickOpenCG(){ 
             
            //p1.SetActive(true); 
            //p2.SetActive(true);  //開大窗
            //p3.SetActive(true); 
            //p4.SetActive(true); 
        CGW.SetActive(true);
    }
      public void clickCloseCG(){  //關閉大窗
        
        CGW.SetActive(false);
    }
     public void Open01(){ 
        
            p1.SetActive(true); 
    }
      public void Open02(){ 
        
            p2.SetActive(true); 
    }
      public void Open03(){ 
        
            p3.SetActive(true); 
    }
      public void Open04(){ 
        
            p4.SetActive(true); 
    }
     public void X01(){ 
        
            p1.SetActive(false); 
    }
      public void X02(){ 
        
            p2.SetActive(false); 
    }
      public void X03(){ 
        
            p3.SetActive(false); 
    }
      public void X04(){ 
        
            p4.SetActive(false); 
    }

}
