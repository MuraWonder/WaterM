using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoParallax : MonoBehaviour
{
   public float depth = 1;
   public int Nowlevel; 

    Player player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float realVelocity = player.speed / depth;
        Vector2 pos = transform.position;

        pos.x -= realVelocity * Time.deltaTime;
        
        // if(pos.x <= -70)
        //     pos.x = 40;
        if (Nowlevel == 3){
            if(pos.x <= -30)
            {pos.x = 0; }}  
       else if(pos.x <= -70)
            {pos.x = 40; }

        transform.position = pos;
    }
}
