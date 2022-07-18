using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // public Transform itemCenter;    // 生成的中心點
    public int itemMax, itemMin;   // 物件數量
    public GameObject[] itemPrefabs;    // 生成物件
    public Vector2 itemSpawnCenter;// 生成的中心點
    public Vector2 itemSpawnArea;    // 物件生成的範圍
    public Transform Head,Tail; //地形頭跟尾

    // 設定方塊
    public void Setup()
    {
        int itemCount = Random.Range(itemMin, itemMax + 1);
        List<GameObject> items = new List<GameObject>();
        for (int i = 0; i < itemCount; ++i)
        {
            var itemTemp = Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length)]);
            itemTemp.transform.parent = transform;

            var pos = new Vector2(
                Random.Range(itemSpawnArea.x, -itemSpawnArea.x)/2,
                Random.Range(itemSpawnArea.y, -itemSpawnArea.y)/2);
            itemTemp.transform.localPosition = (itemSpawnCenter + pos)/transform.localScale.x;
        }
    }

    // public void Clear(){
    //     for(int i=0;i<transform)
    // }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawCube(transform.position + (Vector3)itemSpawnCenter, itemSpawnArea);

    }

}
