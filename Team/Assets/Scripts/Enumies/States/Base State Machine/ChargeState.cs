using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeState : State
{
    protected D_ChargeState stateData;

    //최소 범위 체크용

    protected bool isDetectingLedge;
    protected bool isDetectingWall;

    protected int playerDirectionRight;


    //위나 아래로 올라가거나 내려간후 3초가 지나면 다시 imove로
    protected bool isSightPlayer;
    protected float SightTime;
    protected bool inSightY_Player;

    //방향전환 쿨타임.
    private float FlipCooldownTime = 0.5f;
    private float FlipCooldownStartTime;
    private bool isFlipCooldown;


    RaycastHit hit;

    public ChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ChargeState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData; //데이터 받기.
    }

    public override void DoCheck()
    {

        base.DoCheck();



        //체크
        isDetectingLedge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();

        //플레이어 방향 체크
        playerDirectionRight = entity.CheckDirectionRightPlayer();

    }


    public override void Enter()
    {
        base.Enter();

        //쿨타임 
        isFlipCooldown = true;
        FlipCooldownStartTime = Time.time;

        //정찰용.
        SightTime = Time.time;

        isSightPlayer = true;
        inSightY_Player = true;

        entity.SetVelocity(stateData.chargeSpeed);//이동
    }



    public override void Exit()
    {
        base.Exit();
    }



    public override void LogicUpdate()
    {
        base.LogicUpdate();

        checkChase(); //추적.

        //플레이어 방향이 바뀌면 추적하기.
        if (playerDirectionRight != entity.facingDirection && isSightPlayer && isFlipCooldown)
        {//오른쪽에 있으면1,왼쪽에 있으면 -1  //그리고//  오른쪽을 바라보고있으면 1, 왼쪽을 바라보고 있으면 -1

            isFlipCooldown = false;
            FlipCooldownStartTime = Time.time;

            entity.Flip();//방향바꾸기.
            entity.SetVelocity(stateData.chargeSpeed);//이동
        }
    }



    public override void PhysicUpdate()
    {
        base.PhysicUpdate();

    }






    protected void checkChase() //추적.
    {

        //탐색으로 바꿈

        // -1< 만약 플레이어의 y < +1.5정도에 있다면 현재 시간 계속 갱신
        if (entity.player.transform.position.y < entity.transform.position.y + stateData.sightUp && entity.player.transform.position.y > entity.transform.position.y - stateData.sightDown)
        {
            inSightY_Player = true;
            SightTime = Time.time;
        }
        else
        {
            inSightY_Player = false;
        }


        //플립 쿨타운이 지나면 
        if (Time.time > FlipCooldownStartTime + FlipCooldownTime)
        {
            isFlipCooldown = true;
        }

        //시야 안에 없으면 일정시간동안.
        if (Time.time > SightTime + stateData.sightOutTime)
        {
            isSightPlayer = false;
        }

    }




}
