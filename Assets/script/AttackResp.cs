using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackResp : MonoBehaviour
{
public GameObject obstacle;
//public Animator attack; 
public float maxX;
public float minX;
public float maxY;
public float minY;
public float timeBetweenSpawn;
private float spawnTime;
void update(){

if(Time.time > spawnTime){
    spwan();
    spawnTime = Time.time + timeBetweenSpawn;}

}
void spwan(){
    
    float randomX = Random.Range(minX, maxX);
    float randomY = Random.Range(minY, maxY);
    //attack.Play("cat_attack_Animation");
    Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);

}

}
