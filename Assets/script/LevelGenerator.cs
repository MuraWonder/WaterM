using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Start is called before the first frame update
private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200f; //主角生成距離 3
//[SerializeField]private Transform levelPart_1; //內容物關卡 1
[SerializeField]private List<Transform> levelPartList;
[SerializeField]private Transform levelPart_Start; //開場關卡 1
[SerializeField]private Player player;//宣告主角 3

private Vector3 lastEndPosition; //2

   private void Awake() {
       lastEndPosition = levelPart_Start.Find("結束地點").position; //2
       int startingSpawnLevelParts = 5; //開場基本關卡5
       for (int i =0; i < startingSpawnLevelParts; i++){ //每次小於初始數字救生成一個新關卡
           SpawnLevelPart();
       }
       //SpawnLevelPart();//2
    //    Transform lastLevelPartTransform;
    //    lastLevelPartTransform = SpawnLevelPart(levelPart_Start.Find("結束地點").position);        //找到結束點後生成 1
    //    lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("結束地點").position);
    //    lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("結束地點").position);
    //    lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("結束地點").position);

   }
   private void FixedUpdate() {
       if(Vector3.Distance(player.transform.position,lastEndPosition)<PLAYER_DISTANCE_SPAWN_LEVEL_PART) //接近就生成 3
       {   //生成另一個關卡
           SpawnLevelPart();
       }
   }
    private void SpawnLevelPart(){
    Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
    Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition); //2
    lastEndPosition = lastLevelPartTransform.Find("結束地點").position;
    }

   private Transform SpawnLevelPart(Transform levelPart,Vector3 spawnPosition){ //每個生成的基底 1
       Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
       return levelPartTransform;
   }
}
