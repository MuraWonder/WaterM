using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelCreator : MonoBehaviour
{
    private GameObject tilePos;
    private float startUpPosY;
    public float tileWidth = 23f; //21 3D 23f
    public float blackWidth = 5;
    private int heightLevel = 0;
    private GameObject tmpTile;

    private GameObject collectedTiles;
    private GameObject gameLayer;
    private GameObject bgLayer;
    [Header("各種地形")]
    public GameObject[] TilePrefabs; //原創
    public Tile lastTile;


    public float gameSpeed = 15f;//2
    private float outofbounceX;//2
    private int blankCounter = 0;//2
    private int middleCounter = 0;//2
    //private string lastTile = "right";//2

    
    // Start is called before the first frame update
    void Start()
    {   
        gameLayer = GameObject.Find("gameLayer");
        //bgLayer = GameObject.Find("backgroundLayer"); //2
        collectedTiles = GameObject.Find("tiles");
        for (int j = 0; j < TilePrefabs.Length; j++) //0~到新增次數
        {   
            GameObject tmpParent = new GameObject(j.ToString()); //建立母物件 t
            tmpParent.transform.SetParent(collectedTiles.transform);
            for (int i = 0; i < 20; i++)
            {   

                GameObject tmpg1 = Instantiate(TilePrefabs[j], tmpParent.transform);
                tmpg1.name = j.ToString();
                tmpg1.transform.localPosition = Vector3.zero;
            }

            // GameObject tmpg1 = Instantiate(Resources.Load("PreS", typeof(GameObject))) as GameObject; //pre東西
            // tmpg1.transform.parent = collectedTiles.transform.Find("1").transform; //資料夾位置
            // tmpg1.transform.position = Vector2.zero; //?東西
            // GameObject tmpG2 = Instantiate(Resources.Load("PreM", typeof(GameObject))) as GameObject;
            // tmpG2.transform.parent = collectedTiles.transform.Find("2").transform;
            // tmpG2.transform.position = Vector2.zero;
            // GameObject tmpG3 = Instantiate(Resources.Load("PreE", typeof(GameObject))) as GameObject; //3d
            // tmpG3.transform.parent = collectedTiles.transform.Find("3").transform;
            // tmpG3.transform.position = Vector2.zero;
            // GameObject tmpG4 = Instantiate(Resources.Load("blank", typeof(GameObject))) as GameObject;
            // tmpG4.transform.parent = collectedTiles.transform.Find("b").transform;
            // tmpG4.transform.position = Vector2.zero;
        }
        collectedTiles.transform.position = new Vector2(-80.0f, -50.0f);
        tilePos = GameObject.Find("startTilePosition"); //第一個
        startUpPosY = tilePos.transform.position.y;
        outofbounceX = tilePos.transform.position.x - 30.0f;//2 離開場景30.of

        // fillScene();

    }

    // Update is called once per frame
    void FixedUpdate()//2移動
    {
        gameLayer.transform.position = new Vector2(gameLayer.transform.position.x - gameSpeed * Time.deltaTime, 0);

        foreach (Transform child in gameLayer.transform) //檢查每個gamelayer底下的物件
        {
            Tile tergetTile = child.GetComponent<Tile>();
            if (tergetTile == null) { continue; }
            if (tergetTile.Tail.position.x < outofbounceX)
            {
                child.parent = collectedTiles.transform.Find(child.name);
                child.localPosition = Vector3.zero;

                // switch (child.gameObject.name)
                // {

                //     case "PreS(Clone)":
                //         child.gameObject.transform.position = collectedTiles.transform.Find("1").transform.position;
                //         child.gameObject.transform.parent = collectedTiles.transform.Find("1").transform;
                //         break;
                //     case "PreE(Clone)":
                //         child.gameObject.transform.position = collectedTiles.transform.Find("3").transform.position;
                //         child.gameObject.transform.parent = collectedTiles.transform.Find("3").transform;
                //         break;
                //     case "blank(Clone)":
                //         child.gameObject.transform.position = collectedTiles.transform.Find("b").transform.position;
                //         child.gameObject.transform.parent = collectedTiles.transform.Find("b").transform;
                //         break;
                //     case "PreM(Clone)":
                //         child.gameObject.transform.position = collectedTiles.transform.Find("2").transform.position;
                //         child.gameObject.transform.parent = collectedTiles.transform.Find("2").transform;   //3d
                //         break;
                //     default:
                //         Destroy(child.gameObject);
                //         break;
                // }

            }

        }
        if (gameLayer.transform.childCount < 10)
        {
            spawmTile();
            //print("spwan");
        }

    }
    private void fillScene()
    {
        for (int i = 0; i < 2; i++)
        { //4
            setTile("middle");
        }
        setTile("right");
    }

    public void setTile(string type)
    {
        float xDst = 0f; // x軸距離
        switch (type)
        {
            case "left":
                xDst = tileWidth;
                tmpTile = collectedTiles.transform.Find("1").transform.GetChild(0).gameObject;
                tmpTile.GetComponent<Tile>().Setup();
                break;
            case "right":
                xDst = tileWidth;
                tmpTile = collectedTiles.transform.Find("3").transform.GetChild(0).gameObject; //3d
                tmpTile.GetComponent<Tile>().Setup();
                break;
            case "middle":
                xDst = tileWidth;
                tmpTile = collectedTiles.transform.Find("2").transform.GetChild(0).gameObject; //3d
                tmpTile.GetComponent<Tile>().Setup();
                break;
            case "blank":
                xDst = blackWidth;
                tmpTile = collectedTiles.transform.Find("b").transform.GetChild(0).gameObject;
                break;
        }

        // tmpTile.transform.position = new Vector2(tilePos.transform.position.x+(tileWidth/2+3),startUpPosY+(heightLevel*tileWidth/7));
        tmpTile.transform.position = new Vector2(tilePos.transform.position.x + (xDst), startUpPosY);

        tilePos = tmpTile;
        //lastTile = type;//2    tilewidth/2 && 後面的tileWidth/7
    }


    private void spawmTile()
    {
        Vector3 Pos = lastTile.Tail.position;
        int Rand = Random.Range(0, TilePrefabs.Length);
        GameObject TileObj = collectedTiles.transform.Find(Rand.ToString()).transform.GetChild(0).gameObject;
        Tile tile = TileObj.GetComponent<Tile>();
        tile.transform.parent = gameLayer.transform;
        tile.transform.position = Pos - tile.Head.localPosition;
        lastTile = tile;
        // if (blankCounter > 0)
        // {

        //     setTile("blank");
        //     blankCounter--;
        //     return;

        // }
        // if (middleCounter > 0)
        // {

        //     setTile("middle");
        //     middleCounter--;
        //     return;

        // }
        // if (lastTile == "blank")
        // {

        //     //changeHeight();
        //     setTile("left"); //3d
        //     middleCounter = (int)Random.Range(3, 5);//1,4  3~5

        // }
        // else if (lastTile == "right")
        // {

        //     blankCounter = (int)Random.Range(5, 10); //3為二連跳
        // }
        // else if (lastTile == "middle")
        // {
        //     setTile("right");
        // }

    }
    private void changeHeight() //2
    {
        int newHeightLevel = (int)Random.Range(1, 2);//-1,2
        if (newHeightLevel < heightLevel)
            heightLevel--;
        else if (newHeightLevel > heightLevel)
            heightLevel++;
    }



}
