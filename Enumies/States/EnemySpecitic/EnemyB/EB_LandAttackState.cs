using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EB_LandAttackState : LandAttackState
{

    private EnemyB enemy;


    public EB_LandAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform LandattackPosition, D_LandAttackState stateData, EnemyB enemy)
            : base(entity, stateMachine, animBoolName, LandattackPosition, stateData)
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
        isAttacking = false;
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
