using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EA_PlayerDetectedState : PlayerDetectedState
{
    private EnemyA enemy;

    public EA_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, EnemyA enemy)
        : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (performCloseRangeAction)
        {
            stateMachine.ChangeState(enemy.dashAttackState);
        }

        //지켜보는 시간이 끝나면.
        else if (performLongRangeAction)
        {
            stateMachine.ChangeState(enemy.chargeState); //추적으로 바꾸기
        }
        else if (!isPlayerInMaxAgroRange)
        {
            stateMachine.ChangeState(enemy.moveState);
        }

        //if(!isPlayerInMaxAgroRange) //// 감지하지 않았으면.
        //{
        //    enemy.idleState.SetFlipAfterIdle(false);
        //    stateMachine.ChangeState(enemy.idleState); //아이들로 바꾸기 .
        //}
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
