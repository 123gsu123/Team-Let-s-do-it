using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : Entity
{   

     public EA_IdleState idleState { get; private set; }

     public EA_MoveState moveState { get; private set; }
   
    public EA_ChargeState chargeState { get; private set; }

    public EA_DashAttackState dashAttackState { get; private set; }


    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    

    [SerializeField]
    private D_ChargeState chargeStateData;

    [SerializeField]
    private D_DashAttack dashAttackStateData;

    [SerializeField]
    private Transform dashAttackPosition;

    public override void Start()
    {
        base.Start();

        //새로 이동관련 인자 받기.
        moveState = new EA_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new EA_IdleState(this, stateMachine, "idle", idleStateData, this);
       
        chargeState = new EA_ChargeState(this, stateMachine, "charge", chargeStateData, this);

        dashAttackState = new EA_DashAttackState(this, stateMachine, "meleeAttack", dashAttackPosition, dashAttackStateData, this);

        stateMachine.Initialize(moveState); //시작을 이동으로 넣기.
    }


     public override void Update()
    {
        base.Update();
        CheckKnockback();

        if (currentHealth <= 0)
            Die();

    }

    private void Damage(AttackDetails attackDetails)
    {
        
        int direction;

        //체력깍고
        currentHealth -= attackDetails.damageAmount;

        if (attackDetails.position.x < transform.position.x)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }

        //direction 방향으로 넉백 받기.
        Knockback(direction);

    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(dashAttackPosition.position, dashAttackStateData.attackRadius);
    }
    private void Die()
    {
        transform.gameObject.SetActive(false);
    }

}
