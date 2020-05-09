using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EA_IdleState : IdleState
{

    private EnemyA enemy;
    private int RandomDirection;
    private int idlemode;
    private bool FinePlayer;

    public EA_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, EnemyA enemy) 
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
        randomIdleMode();// 어떤것을 할것인지 뽑는다.
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //발견하면.
        if (FinePlayer)
        {
           
            stateMachine.ChangeState(enemy.chargeState);//추적모드로 바꿈
        }

        else if (isIdleTimeOver)
        {
            CheckIdleMode();
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    //-Athor Funtion-----------------------\


    private void CheckIdleMode()
    {
            isIdleTimeOver = true;


            if (idlemode == 0)//0은 다시 뽑기.
            { 
                isIdleTimeOver = false;
                SetRandomIdleTime();//다시 얼마나 기다릴건지 뽑는다.
                randomIdleMode();//모드 랜덤뽑기. 1이면 다시 뽑고, 2면 넘긴다.
            }
            else if (idlemode == 1)//1가 나오면 움직인다.
            {
                if (RandomDirection == 1)//랜덤 방향이 1나오면 플립한다.
                    entity.Flip();
                stateMachine.ChangeState(enemy.moveState);
            }
    }


    private void randomIdleMode()
    {
        idlemode = Random.Range(0, 2);
        RandomDirection = Random.Range(0, 2);
    }
}
