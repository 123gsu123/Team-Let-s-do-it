using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EA_MoveState : MoveState
{

    private EnemyA enemy;

    private int Movemode;
    private int RandomDirection;


    private bool isChaseTimeOver;
    private bool isMoveTimeOver;

    private bool FinePlayer;

    private float moveTime;
    private float distance;





    public EA_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, EnemyA enemy)
        : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void DoCheck()
    {
        base.DoCheck();
        FinePlayer = entity.CheckFIndPlayer();//플레이어 발견 체크.


    }

    public override void Enter()
    {

        base.Enter();


        randomMoveMode();//모드 뽑는다 . 1이면 다시 뽑고, 2면 기다린다.
        SetRandomMoveTime();//얼마나 기다릴건지 뽑는다.
        isMoveTimeOver = false;


    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isMoveTimeOver)//돌아다닐 시간이 끝나면.
        {
            CheckMovemode();//모드 체크.
        }

        //플레이어 발견하면.
        if (FinePlayer)
        {
            stateMachine.ChangeState(enemy.chargeState);//추적으로 바꾸고.
        }

        else if (!isDetectingLedge || isDetectingWall)//디텍티드용
        {
            //만약 절벽이나 벽에 닿으면  플립하고 다시 걷기.
            entity.Flip();
            entity.SetVelocity(stateData.movementSpeed);//이동
        }

    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    //-Athor Funtion-----------------------


    private void CheckMovemode()//체크 무브 모드.
    {
        if (Time.time > startTime + moveTime)
        {
            isMoveTimeOver = true;

            if (Movemode == 0)//0 이 나오면다시 난수 돌려서 돌아다니기
            {
                isMoveTimeOver = false;

                //시간 다시넣기.
                startTime = Time.time;
                SetRandomMoveTime();//다시 얼마나 기다릴건지 뽑는다.

                randomMoveMode();//모드 뽑는다 . 1이면 다시 뽑고, 2면 기다린다.

            }
            else if (Movemode == 1)//1이 나오면 아이들로 돌아가서 아이들 패턴으로
            {
                stateMachine.ChangeState(enemy.idleState);
            }

            randomMoveMode();//모드 랜덤뽑기

        }
    }



    private void randomMoveMode()
    {
        //0 or 1
        Movemode = Random.Range(0, 2);
    }

    private void SetRandomMoveTime()// 가만히 서있을 시간 랜덤 부여.,
    {
        moveTime = Random.Range(stateData.minMoveTime, stateData.maxMoveTime);
    }

}
