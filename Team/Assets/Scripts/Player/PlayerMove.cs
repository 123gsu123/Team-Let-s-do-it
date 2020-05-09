using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    //퀘스트를 얻을시 
    
    public bool Quest;
    public bool Quest1;   

    private bool questCheck;

    GameObject scanObject;

    private int hp = 5;

    private int direction = 1;
    private float moveDirection;
    private bool canJump = true;
    private bool canJump2;
    private bool canJump3;
    private bool canMove = true;
    private bool sliderMove;
    private bool isGround;
    private bool isRun;
    private bool isDashing;
    private bool delaykey = true;
    float originXscale;
    private int newKey = 0;
    [SerializeField]
    private int noOfClick = 0;
    /// //////////////////////
    /// 대쉬 관련
    float lastDash = -100f;
    float dashTimeLeft;
    float lastImageXpos;
    float jumpTimeCounter;
    float jumpTimeCounter2;
    //N단점프조절
    [SerializeField]
    private int canNJump;

    private int nJump;
    [SerializeField]
    private float maxComboDelay = 0.9f;
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float jumpPower;
    [SerializeField]
    private float jumpTime;
    [SerializeField]
    private float rayDistance;
    [SerializeField]
    private float footR;
    [SerializeField]
    private float footL;
    [SerializeField]
    LayerMask checkLayer;
    [SerializeField]
    LayerMask npc;
    [SerializeField]
    private float speed;

    [SerializeField]
    private float radius;
    [SerializeField]
    private float dashTime;
    [SerializeField]
    private float dashSpeed;
    [SerializeField]
    private float distanceBetweenImages;
    [SerializeField]
    private float dashCoolDown;


   
    public GameManager gameManger;
    Rigidbody2D rigid;
    Animator anim;

    void Start()
    {
        nJump = canNJump;
        originXscale = transform.localScale.x;
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        canJump2 = false;
    }
    void FixedUpdate()
    {
        Dash();
        Walk();   
    }
   
    void Update()
    {
        MoveCheck();
        ClickCheck();
        PhysicsCheck();  
        AnimationCheck();
        Animation();      
        QuestCheck();   
    }




    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, radius);
    }

    void Dash()
    {
        if (isDashing)
        {
            if (dashTimeLeft > 0)
            {
                canMove = false;
                gameObject.layer = 16;
                rigid.velocity = new Vector2(dashSpeed * direction, rigid.velocity.y);
                dashTimeLeft -= Time.deltaTime;

                if (Mathf.Abs(transform.position.x - lastImageXpos) > distanceBetweenImages)
                {
                    PlayerAfterrImagePool.Instance.GetFromPool();
                    lastImageXpos = transform.position.x;
                }
            }
            if (dashTimeLeft <= 0)
            {
                isDashing = false;
                canMove = true;

            }
        }
    }
    void AttempToDash()
    {

        isDashing = true;
        dashTimeLeft = dashTime;
        lastDash = Time.time;
        PlayerAfterrImagePool.Instance.GetFromPool();
        lastImageXpos = transform.position.x;
        Dash();
    }


    void ClickCheck()
    {

        if (Input.GetKeyDown(KeyCode.X) && delaykey && noOfClick == 0)
        {
            ++noOfClick;

            noOfClick = Mathf.Clamp(noOfClick, 0, 1);

            if (newKey == 1)
            {
                anim.SetBool("Attack5", true);
                anim.SetBool("Attack1", false);            
            }
        }

        if (noOfClick == 1)
        {
            anim.SetBool("Attack1", true);
        } 
        if(!anim.GetBool("Attack1"))
        {
            delaykey = true;
        }
       
    }

    void returnNew1()
    {
        newKey = 1;
    }
    void returnNew0()
    {
        newKey = 0;
    }
    void returnFalse()
    {
        delaykey = false;
    }
    void return1()
    {       
        if(noOfClick == 1)
        {
            anim.SetBool("Attack2", true);          
        }
        else
        {
            anim.SetBool("Attack1", false);
            newKey = 0;
        }
    }

    void return2()
    {
        if (noOfClick == 1)
        {
            anim.SetBool("Attack3", true);
        }
        else
        {
            anim.SetBool("Attack2", false);
            noOfClick = 0;
        }
    }
    void return3()
    {
        if (noOfClick == 1)
        {
            anim.SetBool("Attack4", true);
        }
        else
        {
            anim.SetBool("Attack3", false);
            noOfClick = 0;
        }
    }

    void return4()
    {
        if (noOfClick == 1)
        {
            anim.SetBool("Attack5", true);
        }
        else
        {
            anim.SetBool("Attack4", false);
            noOfClick = 0;
        }
    }

    void return5()
    {
        anim.SetBool("Attack1", false);
        anim.SetBool("Attack2", false);
        anim.SetBool("Attack3", false);
        anim.SetBool("Attack4", false);
        anim.SetBool("Attack5", false);
        noOfClick = 0;
        newKey = 0;

    }
    void return0()
    {
        --noOfClick;
        delaykey = true;
    }
  

    void PhysicsCheck()
    {
        isGround = false;

        questCheck = Physics2D.OverlapCircle(transform.position, radius, npc);
        Collider2D coll = Physics2D.OverlapCircle(transform.position, radius, npc);
        if (questCheck)
        {
            scanObject = coll.gameObject;
        }
        else if (!questCheck)
        {
            scanObject = null;
        }

        RaycastHit2D left = Raycast(new Vector2(footL, 0), Vector2.down, rayDistance);
        RaycastHit2D right = Raycast(new Vector2(footR, 0), Vector2.down, rayDistance);

        if (left || right)
            isGround = true;

    }

    void MoveCheck()
    {

        moveDirection = gameManger.isAction ? 0 : Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGround && !gameManger.isAction)
        {
            jumpTimeCounter = jumpTime;
            jumpTimeCounter2 = jumpTime;
            canJump = true;
            canJump2 = false;
        }
    
        if (Input.GetButton("Jump") && !isGround && !gameManger.isAction && canJump2 && nJump > 0)
        {
            if (jumpTimeCounter2 > 0)
            {
                Jump();
                jumpTimeCounter2 -= Time.deltaTime;
            }
            else if (jumpTimeCounter2 < 0)
            {
                canJump2 = false;               
            }
        }
        if (Input.GetButton("Jump")  && canJump && !gameManger.isAction)
        {
            if (jumpTimeCounter > 0)
            {                
                Jump();
                jumpTimeCounter -= Time.deltaTime;
            }
            else if (jumpTimeCounter < 0)
                canJump = false;
        }
        if (Input.GetButtonUp("Jump"))
        {
            nJump--;
            canJump = false;
            canJump2 = true;
        }
        
   

        if (Input.GetButton("Dash") && moveDirection != 0 && Quest1 && !gameManger.isAction)
        { 
            if (Time.time >= (lastDash + dashCoolDown))
                AttempToDash();
        }
        if (isGround)
        {
            nJump = canNJump;
        }

    }

    void Walk()
    {
        if(canMove)
            rigid.velocity = new Vector2(walkSpeed * moveDirection, rigid.velocity.y);
        
        if(rigid.velocity.x * direction < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        direction *= -1;
        Vector2 scale = transform.localScale;
        scale.x = direction * originXscale;
        transform.localScale = scale;
    }

    void Jump()
    {   
         rigid.velocity = new Vector2(rigid.velocity.x, jumpPower);     
    }

    void AnimationCheck()
    {
        if (moveDirection == 0)
        {
            isRun = false;
        }
        else
            isRun = true;
    }

    void Animation()
    {
        anim.SetBool("isRun", isRun);

    }

    void QuestCheck()
    {
        if(Input.GetKeyDown(KeyCode.F) && questCheck)
        {
            gameManger.Action(scanObject);
        }
    }

    RaycastHit2D Raycast(Vector2 offset, Vector2 direction, float distance)
    {
        return Raycast(offset, direction, distance, checkLayer);
    }
    

    RaycastHit2D Raycast(Vector2 offset, Vector2 direction, float distance, LayerMask layerMask)      
    {
        Vector2 pos = transform.position;

        RaycastHit2D rayhit = Physics2D.Raycast(pos, direction, distance, layerMask);

        Color color = rayhit ? Color.red : Color.green;

        Debug.DrawRay(pos + offset, direction * distance, color);

        return rayhit;
    }

}
