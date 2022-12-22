using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

public class Player : MonoBehaviour
{   //public GameObject player; //為了強制移動而加
    public Shake Shake;
    //public GameObject UItip1; //開場UI
    //public GameObject UItip2;
    //public GameObject UItip3;
    public int maxJump;
    public int nowJump;
    
    public float speed;
    public float jumpHigh; //外加跳躍
    Vector3 originScale;
    bool move;
    [Header("表情UI")]
    public Image Emotion; //鰾情
    public Sprite dEmotionSprite; //正常鰾情 defult
    public Sprite hEmotionSprite; //撞到障礙表情 hit


    public Animator anim; //宣告動畫器的名稱叫做anim
    public Animator popAnim; 
    public GameObject Text01;

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
    public GameOverScreen GameOverScreen;//呼喚gameover的畫面
    public QTEs QTEs;//呼喚QTE的畫面
    
    public AudioSource BGMusic; //宣告我有一格音樂
    //public int Nowlevel;

    // Start is called before the first frame update
    void Start()
    {   //player.GetComponent<Talkmove>();
        anim = GetComponent<Animator>(); //抓play底下動畫器
        //popAnim = GetComponent<Animator>(); 
        GameOverScreen.GetComponent<GameOverScreen>().isblack = false;
        originScale = transform.localScale;
        
        RB = GetComponent<Rigidbody2D>();
        //RB.freezeRotation = true;
        anim.Play("mainRuningame");

       if(s_maxHealth==0){
           health = maxHealth;
           s_maxHealth = maxHealth;
       }
       if(s_maxHealth2==0){
           health2 = maxHealth2;
           s_maxHealth2 = maxHealth2;
       }
       maxJump = 2;
       nowJump = 0;
       
    //    if (Nowlevel == 1){
    //    StartCoroutine(SetUIHide(8));
    //    }
    }

    // Update is called once per frame
    void Update()
     {   //RaycastHit2D hitGround = Physics2D.Raycast (groundRayObject.transform.position,-Vector2.up);
          // Debug.DrawRay(groundRayObject.transform.position,-Vector2.up*hitGround.distance,Color.red);
        if (canMove)
        {   if(nowJump!=maxJump){
            if(Input.GetKeyDown(KeyCode.W)) //GetKeyDown
            {   nowJump += 1;
                Debug.Log("+1");
                // Vector3 vector3 = new Vector3(gameObject.transform.position.x,jumpHigh- speed * Time.deltaTime,0);
                // gameObject.transform.position = vector3;
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpHigh;
                //move = true;
                transform.localScale = Vector3.Scale(originScale, new Vector3(1, 1, 1));
                StartCoroutine(SetAnimFly(1));
                
            }
            }
            if(Input.GetKey(KeyCode.S))
            {
                gameObject.GetComponent<Rigidbody2D>().velocity -= Vector2.up*jumpHigh*.1f;
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
                //anim.Play("fly");
            }
            else
            {
                //anim.Play("mainRuningame");
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
        if(tokei.GetComponent<Timer>().currenttime<10)
        {
         Shake.ShakeIt();
        }
        if(tokei.GetComponent<Timer>().currenttime>10)
        {Shake.GetComponent<Shake>().Targetshaking = false;}
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
            tokei.GetComponent<Timer>().currenttime += 0.4f;
            collectSound.volume = 1f;
            collectSound.Play();
            ScoreSystem.theScore += 100;
            ScoreSystem.theCollect += 1;
            Destroy(other.gameObject);
        }
         if(other.gameObject.tag=="PlusPlus")
        {
            tokei.GetComponent<Timer>().currenttime += 5.0f;
            collectSound.volume = 0.1f;
            collectSound.Play();
            ScoreSystem.theScore += 500;
            ScoreSystem.theCollect += 1;
            popAnim.Play("pop1");
            Destroy(other.gameObject);
           
        }
         if(other.gameObject.tag=="Obstacle")
        {   
            StartCoroutine(SetAnimHit(1));
            tokei.GetComponent<Timer>().currenttime -= 3.0f;
            hitSound.Play();
            Destroy(other.gameObject);
            StartCoroutine(SetEmotion(2)); //表情兩秒
            CameraShaker.Instance.ShakeOnce(4f,4f,1f,1f);
            Shake?.ShakeMe();
            
        }
         if(other.gameObject.tag=="ObstacleS")
        {   
            StartCoroutine(SetAnimHit(1));
            tokei.GetComponent<Timer>().currenttime -= 0.0f;
            hitSound.Play();
            Destroy(other.gameObject);
            QTEs.GetComponent<QTEs>().ishit = true;
            StartCoroutine(SetEmotion(2)); //表情兩秒
            CameraShaker.Instance.ShakeOnce(4f,4f,1f,1f);
            Shake?.ShakeMe();
            
        }
        if(other.gameObject.tag=="DeathZone")
        {   BGMusic.Stop();
            GameOverScreen.DvideoFirst();

        }
        
       
       
    }
    private void OnCollisionEnter2D(Collision2D GGo)
    {     
            if(GGo.gameObject.tag=="Ground")
            {   nowJump=0;
                //Debug.Log("屌");
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
   
    // IEnumerator SetUIHide (float time)
    // {   
    //     yield return new WaitForSeconds (time);
    //     UItip1?.SetActive(false);
    //     UItip2?.SetActive(false);
    //     UItip3?.SetActive(false);
    // }
   
}
