using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoParallax : MonoBehaviour
{
   public float depth = 1;

    Player player;

    private void Awake()
    {
        player = GameObject.Find("player 1").GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float realVelocity = player.speed / depth;
        Vector2 pos = transform.position;

        pos.x -= realVelocity * Time.fixedDeltaTime;

        if (pos.x <= -30)
            pos.x = 30;

        transform.position = pos;
    }
}
