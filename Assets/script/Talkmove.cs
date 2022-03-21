using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talkmove : MonoBehaviour
{   public Transform target;
    public float t;
    public float speed;
    private GameObject player;
    

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    async void FixedUpdate()
    {
        //gameObject.transform.position+=new Vector3(7f* Time.deltaTime,0,0);
      Vector3 a = transform.position;
      Vector3 b = target.position;
      transform.position = Vector3.MoveTowards(a,b,speed);
      player.GetComponent<Player>().canMove = false;
      if(a.x == b.x){
        player.GetComponent<Player>().canMove = true;
      this.enabled = false;
      }



    }
}