using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{   //public GameObject player; //為了強制移動而加
    public float speed;
    public float jumpHigh; //外加跳躍
    Vector3 originScale;
    bool move;
    //public Animator anim;

    public float maxHealth;
    public static float s_maxHealth;
    public static float health;

    public int life; 


    public float maxHealth2; //最大血
    public static float s_maxHealth2; //扣血
    public static float health2;  //當前血
    [SerializeField]
    public bool canMove = true;    // 學長加的，玩家是否可移動
    public GameObject tokei;
    private Rigidbody2D RB;//防止翻轉
    public AudioSource collectSound;//播放蒐集的聲音
    public AudioSource hitSound;

    // Start is called before the first frame update
    void Start()
    {   //player.GetComponent<Talkmove>();
        //anim = GetComponent<Animator>();
        originScale = transform.localScale;
        RB.freezeRotation = true;

       if(s_maxHealth==0){
           health = maxHealth;
           s_maxHealth = maxHealth;
       }
       if(s_maxHealth2==0){
           health2 = maxHealth2;
           s_maxHealth2 = maxHealth2;
       }

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {   if(Input.GetKeyDown(KeyCode.W))
            {
                // Vector3 vector3 = new Vector3(gameObject.transform.position.x,jumpHigh- speed * Time.deltaTime,0);
                // gameObject.transform.position = vector3;
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpHigh;
                move = true;
                transform.localScale = Vector3.Scale(originScale, new Vector3(1, 1, 1));
                
            }
            // if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            // {
            //     Vector3 vector3 = new Vector3(gameObject.transform.position.x - speed * Time.deltaTime, gameObject.transform.position.y, 0);
            //     gameObject.transform.position = vector3;
            //     move = true; //有在動的提示
            //     transform.localScale = Vector3.Scale(originScale, new Vector3(-1, 1, 1));
            // }
            // if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            // {
            //     Vector3 vector3 = new Vector3(gameObject.transform.position.x + speed * Time.deltaTime, gameObject.transform.position.y, 0);
            //     gameObject.transform.position = vector3;
            //     move = true;
            //     transform.localScale = Vector3.Scale(originScale, new Vector3(1, 1, 1));
            // }
            // if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.D))
            // { move = false; }
            if (move == true) //有在動就播動畫
            {
                //anim.Play("Run");
            }
            else
            {
                //anim.Play("Breath");
            }
        }
        else
        {  
            //  if(player.GetComponent<Talkmove>().force == true)
            // {anim.Play("Run");}
            //anim.Play("Breath");
        }
    }
    


    public void SetCanMove(bool b)  // 學長加的，設定是否可移動
    {
        canMove = b;
    }

    public void Move(bool b)  // yee
    {
        move = b;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Obstacle"){
            health -= 2.0f;
        }
        // if(other.gameObject.tag=="Wronganswer"){
        //     health2-= 2.0f;
        // }
        //之前問答血量
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Plustime")
        {
            tokei.GetComponent<Timer>().currenttime += 10.0f;
            collectSound.Play();
            ScoreSystem.theScore += 100;
            ScoreSystem.theCollect += 1;
            Destroy(other.gameObject);
        }
         if(other.gameObject.tag=="Obstacle")
        {
            tokei.GetComponent<Timer>().currenttime -= 5.0f;
            hitSound.Play();
            Destroy(other.gameObject);
        }
    }
   
}
