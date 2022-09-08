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
    [Header("表情UI")]
    public Image Emotion; //鰾情
    public Sprite dEmotionSprite; //正常鰾情
    public Sprite hEmotionSprite; //撞到障礙表情


    public Animator anim; //宣告動畫器的名稱叫做anim

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
    //private Rigidbody2D RB;//防止翻轉
    public AudioSource collectSound;//播放蒐集的聲音
    public AudioSource hitSound;
    public GameOverScreen GameOverScreen;//呼喚gameover的畫面
    
    public AudioSource BGMusic; //宣告我有一格音樂

    // Start is called before the first frame update
    void Start()
    {   //player.GetComponent<Talkmove>();
        anim = GetComponent<Animator>(); //抓play底下動畫器
        GameOverScreen.GetComponent<GameOverScreen>().isblack = false;
        originScale = transform.localScale;
        //RB = GetComponent<RigidBody2D>();
        //RB.freezeRotation = true;

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
        {   if(Input.GetKeyDown(KeyCode.W)) //GetKeyDown
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
                anim.Play("fly");
            }
            else
            {
                anim.Play("mainRuningame");
            }
        }
        else
        {  
            //  if(player.GetComponent<Talkmove>().force == true)
            // {anim.Play("Run");}
            //anim.Play("Breath");
        }
        if(tokei.GetComponent<Timer>().currenttime==0)
        {BGMusic.Stop();
         GameOverScreen.DvideoFirst();
         enabled=false;}
    }
    


    public void SetCanMove(bool b)  // 學長加的，設定是否可移動
    {
        canMove = b;
    }

    public void Move(bool b)  // yee
    {
        move = b;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Plustime")
        {
            tokei.GetComponent<Timer>().currenttime += 1.0f;
            collectSound.volume = 0.2f;
            collectSound.Play();
            ScoreSystem.theScore += 100;
            ScoreSystem.theCollect += 1;
            Destroy(other.gameObject);
        }
         if(other.gameObject.tag=="Obstacle")
        {   
            StartCoroutine(SetAnimHit(1));
            tokei.GetComponent<Timer>().currenttime -= 3.0f;
            hitSound.Play();
            Destroy(other.gameObject);
            StartCoroutine(SetEmotion(2)); //表情兩秒

        }
        if(other.gameObject.tag=="DeathZone")
        {   BGMusic.Stop();
            GameOverScreen.DvideoFirst();

        }
       
    }
    IEnumerator SetEmotion (float time)
    {
    Emotion.sprite = hEmotionSprite;   //狀表情
    yield return new WaitForSeconds (time);//等秒數
    Emotion.sprite = dEmotionSprite;  //喚回預設表情 

    }
    IEnumerator SetAnimHit (float time)
    {   anim.Play("HIT");
        yield return new WaitForSeconds (time);
        anim.Play("mainRuningame"); }

        IEnumerator SetAnimFly (float time)
    {   anim.Play("fly");
        yield return new WaitForSeconds (time);
        anim.Play("mainRuningame"); }
   
}
