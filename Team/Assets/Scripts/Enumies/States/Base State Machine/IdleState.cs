using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    protected D_IdleState stateData;

    protected bool flipAfterIdle;
    protected bool isIdleTimeOver;

    //디텍치용
    protected bool isPlayerInMinAgroRange;



    protected float idleTime;

    public IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData; //데이터 받기.
    }

    public override void DoCheck()
    {
        base.DoCheck();

        //디텍치용
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();

    }

    public override void Enter()
    {
        base.Enter();

        entity.SetVelocity(0f);
        isIdleTimeOver = false;

        SetRandomIdleTime(); //얼마나 멈춰있을건지 난수 돌리기.
    }

    public override void Exit()
    {
        base.Exit();

        //나갈때 플립.
        if (flipAfterIdle)
        {
            entity.Flip();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time > startTime + idleTime)
        {
            isIdleTimeOver = true;
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public void SetFlipAfterIdle(bool filp)
    {
        flipAfterIdle = filp;
    }

    protected void SetRandomIdleTime()// 가만히 서있을 시간 랜덤 부여.,
    {
        idleTime = Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
    }

}
