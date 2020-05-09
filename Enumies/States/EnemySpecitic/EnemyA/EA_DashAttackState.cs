using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EA_DashAttackState : DashAttackState
{
    private EnemyA enemy;


    public EA_DashAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_DashAttack stateData, EnemyA enemy) 
        : base(entity, stateMachine, animBoolName, attackPosition, stateData)
    {
        this.enemy = enemy;
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();


        //공격이 끝나면
        if (!isAttacking)
        {
            stateMachine.ChangeState(enemy.chargeState);//추적으로
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}
