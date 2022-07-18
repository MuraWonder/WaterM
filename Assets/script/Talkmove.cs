using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talkmove : MonoBehaviour
{
    public Transform target;
    //public float t;
    public float speed;
    private GameObject player;
    public bool force;



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
        Vector3 b = new Vector3(target.position.x, a.y, a.z);
        transform.position = Vector3.MoveTowards(a, b, speed);
        if (Vector2.Distance(a, b) > 0.1f)
        {

            player.GetComponent<PlayerCanMove>().canMove = false;
            force = true;
            player.GetComponent<PlayerCanMove>().anim.Play("Run");
        }

        if (a.x == b.x)
        {
            player.GetComponent<PlayerCanMove>().canMove = true;
            this.enabled = false;
            force = false;
        }



    }
}
