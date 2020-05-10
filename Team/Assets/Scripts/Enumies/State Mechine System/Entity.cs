using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    public FiniteStateMachine stateMachine; //초기화 및 상태 변환.

    public D_Entity entityData;

    public int facingDirection { get; private set; }

    public Rigidbody2D rb { get; private set; }

    public Animator anim { get; private set; }

    //public GameObject aliveGO { get; private set; }

    public AnimationToStatemachine atsm { get; private set; }


    public float playerDistance;

    //추적용
    public GameObject player;


    //넉백용//
    [SerializeField]
    private float knockbackSpeedX;
    [SerializeField]
    private float knockbackSpeedY;
    [SerializeField]
    private float knockbackDuration;
    [SerializeField]
    private float knockbackDeathSpeedX;
    [SerializeField]
    private float knockbackDeathSpeedY;
    [SerializeField]
    private bool applyKnockback;//넉백 중인지 확인용

    private float knockbackStart;
    private bool playerOnLeft;
    private bool isknockback;
    ///////
  


    [SerializeField]
    protected float maxHealth;


    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private Transform ledgeCheck;
    [SerializeField]
    private Transform playerCheck;


    private Vector2 velocityWorkspace;

    public virtual void Start()
    {
        maxHealth = entityData.hp;

        facingDirection = 1; //기본 오른쪽

        //aliveGO = transform.Find("Alive").gameObject;// 이름 무조건 Alive.
        //rb = aliveGO.GetComponent<Rigidbody2D>();
        //anim = aliveGO.GetComponent<Animator>();

        //aliveGO = transform.Find("Alive").gameObject;// 이름 무조건 Alive.
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


        atsm = GetComponent<AnimationToStatemachine>();

        player = GameObject.Find("Player"); //플레이어찾기.




        stateMachine = new FiniteStateMachine();
    }

    public virtual void Update()
    {
        
        stateMachine.currentState.LogicUpdate();



    }

    public virtual void FixedUpdate()
    {
        
        stateMachine.currentState.PhysicUpdate();
        
    }


    public virtual void SetVelocity(float velocity)
    {//이동 셋.
        
        velocityWorkspace.Set(facingDirection * velocity, rb.velocity.y);
        rb.velocity = velocityWorkspace;
        
    }

    public virtual void SetVelocityVector2(Vector2 velocity)
    {//이동 셋.

       rb.velocity = velocity;

    }





    public virtual bool CheckWall()
    {//벽체크
        //래이캐스트
        return Physics2D.Raycast(wallCheck.position, transform.right, entityData.wallCheckDistance, entityData.whatIsGround);
    }

    public virtual bool CheckLedge()
    {// 바닥체크
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, entityData.ledgeCheckDistance, entityData.whatIsGround);
    }

    public virtual void Flip()
    {//방향전환
        facingDirection *= -1;
        transform.Rotate(0f, 180f, 0f);
    }

    public virtual bool CheckPlayerInMinAgroRange()
    {
<<<<<<< HEAD
<<<<<<< HEAD
        return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, entityData.minAgroDistance, entityData.whatIsPlayer );
=======
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.minAgroDistance, entityData.whatIsPlayer );
>>>>>>> parent of 6aa68389... TA 추가
=======
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.minAgroDistance, entityData.whatIsPlayer );
>>>>>>> parent of 6aa68389... TA 추가
    }

    public virtual bool CheckPlayerInMaxAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.maxAgroDistance, entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.closeRangeActionDistance, entityData.whatIsPlayer);
    }



    public virtual bool CheckFIndPlayer()
    {
        Vector2 temp;
        temp.x = playerCheck.position.x;
        temp.y = playerCheck.position.y;
        if (Physics2D.Raycast(temp, transform.right, 7f, entityData.whatIsPlayer))
        {
            return true;
        }
        else if (Physics2D.Raycast(temp, transform.right * -1, 3f, entityData.whatIsPlayer))
        {
            return true;
        }
        else { return false; }
    }


    public virtual int CheckDirectionRightPlayer()
    {

        float playerX = player.transform.position.x;

        if (playerX > transform.position.x)
        {
            return 1;
        }
        else if (playerX <= transform.position.x)
        {
            return -1;
        }
        else
        {
            return 1;
        }

    }

    public void updatePlayerDistance()
    {
       playerDistance = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(player.transform.position.x, player.transform.position.y));

    }

    protected void CheckKnockback()
    {
        if (Time.time >= knockbackStart + knockbackDuration && isknockback)//넉백중이면
        {
            isknockback = false;//끄기
            rb.velocity = new Vector2(0.0f, rb.velocity.y);//제자리 되돌아오기.
        }
    }

    protected void Knockback(int direction)//넉백
    {

        isknockback = true;
        knockbackStart = Time.time; //시간 넣기.
        rb.velocity = new Vector2(knockbackSpeedX * direction, knockbackSpeedY);//상하 좌우로 밀기
    }


    public virtual void OnDrawGizmos()
    {//기즈모 그리기.
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * facingDirection * entityData.wallCheckDistance));//벽
        //Gizmos.DrawLine(attackCheck.position, attackCheck.position + (Vector3)(Vector2.right * facingDirection * entityData.AtteckCheckDistance));//공격
       // Gizmos.DraLine(wallCheck.position, wallCheck.position + new Vector3(wallCheck.position.x + facingDirection, wallCheck.position.y, wallCheck.position.z);
       Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDistance));//땅

        Debug.DrawRay(new Vector2(playerCheck.position.x, playerCheck.position.y),transform.right * 7f, Color.red);
        Debug.DrawRay(new Vector2(playerCheck.position.x, playerCheck.position.y),transform.right * -1 * 3f, Color.blue);
    }


}
