using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EA_ChargeState : ChargeState
{
    private EnemyA enemy;



    public EA_ChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ChargeState stateData, EnemyA enemy)
        : base(entity, stateMachine, animBoolName, stateData)
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


    public override void LogicUpdate()
    {
        base.LogicUpdate();

        entity.updatePlayerDistance(); //거리 측정.
        //공격범위 안에 들어오면 공격.,, 플레이어를 보고있으면 공격.
        if (inSightY_Player && entity.playerDistance < stateData.AttakArange && (playerDirectionRight == entity.facingDirection))
        {
            stateMachine.ChangeState(enemy.dashAttackState);//공격으로 바꿈
        }
        //플레이어가 같은 축에 없다시피 하면.
        else if (!isSightPlayer)
        {
            entity.Flip();
            stateMachine.ChangeState(enemy.moveState); //탐색으로 바꿈
        }
        //탐색으로 바꿈

        

        //벽이나 다른것에 닿으면.
        else if (!isDetectingLedge || isDetectingWall)
        {
            entity.Flip();
            stateMachine.ChangeState(enemy.moveState); //탐색으로 바꿈
        }

       


    }


    public override void PhysicUpdate()
    {
        base.PhysicUpdate();


    }


}
