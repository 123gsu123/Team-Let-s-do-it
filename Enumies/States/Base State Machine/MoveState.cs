using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    protected D_MoveState stateData;

    protected bool isDetectingWall; //벽에 닿고있음
    protected bool isDetectingLedge; //땅에서 떨어짐 .

    //디텟치용
    protected bool isPlayerInMinAgroRange;


    public MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoCheck()
    {
        base.DoCheck();

        //체크
        isDetectingLedge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();

        //디텍치용
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange(); //래이캐스트!

    }

    public override void Enter()
    {
        base.Enter();

        entity.SetVelocity(stateData.movementSpeed);//이동

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
}
