using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    protected Transform attackPosition;

    
    protected bool isAttacking;  //
    protected bool isPlayerInMinAgroRange;//플레이어 최소거리.


    public AttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName,Transform attackPosition)
        : base(entity, stateMachine, animBoolName)
    {

        this.attackPosition = attackPosition;
    }

    public override void DoCheck()
    {
        base.DoCheck();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }

    public override void Enter()
    {
        base.Enter();

        entity.atsm.attackState = this;

        isAttacking = true;

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public virtual void TriggerAttack()
    {

    }

    public virtual void FinishAttack()
    {
        
    }

}
