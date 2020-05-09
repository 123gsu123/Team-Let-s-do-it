using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB : Entity
{

    public EB_IdleState idleState { get; private set; }

    public EB_MoveState moveState { get; private set; }

    public EB_ChargeState chargeState { get; private set; }

    //public EB_LandAttackState landAttackState { get; private set; }


    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;


    [SerializeField]
    private D_ChargeState chargeStateData;

    // [SerializeField]
    // private D_LandAttack LandAttackStateData;

    [SerializeField]
    private Transform landAttackPosition;

    public override void Start()
    {
        base.Start();

        //새로 이동관련 인자 받기.
        moveState = new EB_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new EB_IdleState(this, stateMachine, "idle", idleStateData, this);

        chargeState = new EB_ChargeState(this, stateMachine, "charge", chargeStateData, this);

        // landAttackState = new EA_DashAttackState(this, stateMachine, "meleeAttack", landAttackPosition, landAttackStateData, this);

        stateMachine.Initialize(moveState); //시작을 이동으로 넣기.
    }


    public override void Update()
    {
        base.Update();
        CheckKnockback();

        if (maxHealth < 0)
            Die();

    }

    private void Damage(AttackDetails attackDetails)
    {

        int direction;

        //체력깍고
        maxHealth -= attackDetails.damageAmount;

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

        //Gizmos.DrawWireSphere(landAttackPosition.position, landAttackStateData.attackRadius);
        //Gizmos.DrawCube(landAttackPosition.position,    );
    }


    private void Die()
    {
        transform.gameObject.SetActive(false);
    }

}
