using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCanMove : MonoBehaviour
{   //public GameObject player; //為了強制移動而加
    public GameObject UItip1; //隱藏UI
    public GameObject UItip2; //隱藏UI
    public float speed;

    Vector3 originScale;
    bool move;
    public Animator anim;

    [SerializeField]
    public bool canMove = false;    // 學長加的，玩家是否可移動

    // Start is called before the first frame update
    void Start()
    {   
        anim = GetComponent<Animator>();
        originScale = transform.localScale;
        StartCoroutine(SetUIHide2(4));
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
         {   
       
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                Vector3 vector3 = new Vector3(gameObject.transform.position.x - speed * Time.deltaTime, gameObject.transform.position.y, 0);
                gameObject.transform.position = vector3;
                move = true; //有在動的提示
                transform.localScale = Vector3.Scale(originScale, new Vector3(-1, 1, 1));
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                Vector3 vector3 = new Vector3(gameObject.transform.position.x + speed * Time.deltaTime, gameObject.transform.position.y, 0);
                gameObject.transform.position = vector3;
                move = true;
                transform.localScale = Vector3.Scale(originScale, new Vector3(1, 1, 1));
            }
            if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.D))
            { move = false; }
            if (move == true) //有在動就播動畫
            {
                anim.Play("Run");
            }
            else
            {
                anim.Play("Breath");
            }
        }
      
    }
    


    public void SetCanMove(bool b)  // 學長加的，設定是否可移動
    {   anim.Play("Breath");
        canMove = b;
    }

    public void Move(bool b)  // yee
    {
        move = b;
    }

      public void toSlevel()
    {
        SceneManager.LoadScene("SLevel");
    }
        public void to02()
    {
        SceneManager.LoadScene("02");
    }
        public void toMenu()
    {
        SceneManager.LoadScene("Menu");
    }
     IEnumerator SetUIHide2 (float time)
    {   
        yield return new WaitForSeconds (time);
        UItip1.SetActive(false);
        UItip2.SetActive(false);
        
    }
}
