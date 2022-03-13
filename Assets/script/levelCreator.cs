using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelCreator : MonoBehaviour
{   private GameObject tilePos;
private float startUpPosY;
private const float tileWidth = 21f;
private int heightLevel = 0;
private GameObject tmpTile;

private GameObject collectedTiles;
private GameObject gameLayer;
private GameObject bgLayer;


    public float gameSpeed = 15f;//2
	private float outofbounceX;//2
	private int blankCounter = 0;//2
	private int middleCounter = 0;//2
    private string lastTile = "right";//2


    // Start is called before the first frame update
    void Start()
    {
        gameLayer = GameObject.Find("gameLayer");
        //bgLayer = GameObject.Find("backgroundLayer"); //2
        collectedTiles = GameObject.Find("tiles");
        for(int i=0; i<20; i++){
           GameObject tmpg1 = Instantiate(Resources.Load("pre1",typeof(GameObject)))as GameObject; //pre東西
           tmpg1.transform.parent =collectedTiles.transform.Find("1").transform; //資料夾位置
           GameObject tmpG2 = Instantiate(Resources.Load("pre2",typeof(GameObject)))as GameObject;
           tmpG2.transform.parent =collectedTiles.transform.Find("2").transform;
           GameObject tmpG3 = Instantiate(Resources.Load("blank",typeof(GameObject)))as GameObject;
           tmpG3.transform.parent =collectedTiles.transform.Find("b").transform;
        }
        collectedTiles.transform.position = new Vector2(-80.0f,-50.0f);
        tilePos = GameObject.Find("startTilePosition");
        startUpPosY = tilePos.transform.position.y;
        outofbounceX = tilePos.transform.position.x - 20.0f;//2 離開場景

        fillScene();

    }

    // Update is called once per frame
    void FixedUpdate()//2移動
    {
        gameLayer.transform.position= new Vector2(gameLayer.transform.position.x-gameSpeed*Time.deltaTime,0);

        foreach (Transform child in gameLayer.transform) {

			if(child.position.x < outofbounceX){

             switch(child.gameObject.name){
					
				case "pre1(Clone)":
					child.gameObject.transform.position = collectedTiles.transform.Find("1").transform.position;
					child.gameObject.transform.parent = collectedTiles.transform.Find("1").transform;
					break;
				case "pre2(Clone)":
					child.gameObject.transform.position = collectedTiles.transform.Find("2").transform.position;
					child.gameObject.transform.parent = collectedTiles.transform.Find("2").transform;
					break;
                case "blank(Clone)":
					child.gameObject.transform.position = collectedTiles.transform.Find("b").transform.position;
					child.gameObject.transform.parent = collectedTiles.transform.Find("b").transform;
					break;
                // default:
				// 	Destroy(child.gameObject);
				// 	break;
             }


            }
            
            
        }
        if(gameLayer.transform.childCount<25)
            spawmTile();
        
    }
    private void fillScene()
    {
        for(int i =0; i<4; i++){
            setTile("middle");
        }
        setTile("right");
    }

public void setTile(string type){
    switch (type){
        // case "left":
        // tmpTile = collectedTiles.transform.Find("1").transform.GetChild(0).gameObject;
        // break;
        case "right":
        tmpTile = collectedTiles.transform.Find("2").transform.GetChild(0).gameObject;
        break; 
        case "middle":
        tmpTile = collectedTiles.transform.Find("1").transform.GetChild(0).gameObject;
        break;
        case "blank":
        tmpTile = collectedTiles.transform.Find("b").transform.GetChild(0).gameObject;
        break;
    }
    tmpTile.transform.parent = gameLayer.transform;
    tmpTile.transform.position = new Vector2(tilePos.transform.position.x+(tileWidth/2),startUpPosY+(heightLevel*tileWidth/7));
    tilePos = tmpTile;
    lastTile = type;//2
}


    private void spawmTile(){
    if (blankCounter > 0) {

			setTile("blank");
			blankCounter--;
			return;

		}
		if (middleCounter > 0) {
			
			setTile("middle");
			middleCounter--;
			return;
			
		}
        if (lastTile == "blank") {

			changeHeight();
			setTile("middle");
			middleCounter = (int)Random.Range(1,2);

		}else if(lastTile =="right"){

			blankCounter = (int)Random.Range(1,2);
		}else if(lastTile == "middle"){
			setTile("right");
		}

    }
     private void changeHeight() //2
	{
		int newHeightLevel = (int)Random.Range(-1,2);
		if(newHeightLevel<heightLevel)
			heightLevel--;
		else if(newHeightLevel>heightLevel)
			heightLevel++;
	}



}
