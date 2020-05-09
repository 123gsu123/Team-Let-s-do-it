using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EB_ChargeState : ChargeState
{
    private EnemyB enemy;



    public EB_ChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ChargeState stateData, EnemyB enemy)
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
        //플레이어가 같은 축에 없다시피 하면.
        if (!isSightPlayer)
        {
            entity.Flip();
            stateMachine.ChangeState(enemy.moveState); //탐색으로 바꿈
        }
        //탐색으로 바꿈

        base.LogicUpdate();

        //벽이나 다른것에 닿으면.
        if (!isDetectingLedge || isDetectingWall)
        {
            entity.Flip();
            stateMachine.ChangeState(enemy.moveState); //탐색으로 바꿈
        }

        entity.updatePlayerDistance(); //거리 측정.
        //공격범위 안에 들어오면 공격.,, 플레이어를 보고있으면 공격.
        //if (inSightY_Player && entity.playerDistance < stateData.dashAttakArange && (playerDirectionRight == entity.facingDirection))
        //{
        //  //땅 공격.
        //}


    }


    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
