using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;


public class EventScripts : MonoBehaviour
{
    
    //public bool destroyOnEvent = false;//破壞物件=否

    public enum EventType   // 學長淫蕩
    {
        TouchEvent,
        SpaceEvent
    }

    bool isStaying;

    public EventType eventType = default;
    // public bool TouchEvent; //是否為可觸碰物件

    public string ChatName;

    [Space(10)]
    public bool GetObject;  //此道具是否能取得
    
    public GameObject[] hide; //臭雞雞
    int Index;
    public int ObjectNumber;    //如果可取得 那編號多少? %第一個編號是0
    private GameObject player;
    private Flowchart flowchart;


    //private BagContro bagContro;//呼喚 背包程式碼




    // Start is called before the first frame update
    void Start()
    {
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        player = GameObject.FindGameObjectWithTag("Player");
        
        //bagContro = GameObject.Find("Bag").GetComponent<BagContro>();//6
    }

    // Update is called once per frame
    void Update()
    {
        if (isStaying && eventType == EventType.SpaceEvent)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                flowchart.ExecuteBlock(ChatName);

                if (GetObject)
                {
                    // bagContro.ObjectList[ObjectNumber] = true;
                    // bagContro.GetObject();

                    //bagContro.GetObject(ObjectNumber);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")  //正在講話
        {
            isStaying = true; //正在講話
            if (eventType == EventType.TouchEvent)
            {
                flowchart.ExecuteBlock(ChatName);
                
               // if(destroyOnEvent){gameObject.SetActive(false);} 用flowchart就能破壞了
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isStaying = false;
            
             //臭 ㄐㄐ
            if(hide.Length != 0){
            for(int i=0; i<hide.Length; ++i){
            hide[i].SetActive(true);
                        }
                      }
        }
    }
}
