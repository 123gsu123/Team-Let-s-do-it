using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAttackState : AttackState
{
    D_DashAttack stateData;

    private float chargetime;


    private float dashTimeLeft;

    private float dashafterTimeLeft;


    protected AttackDetails attackDetails;
    private int dashAttakFaze;


    private bool attackted;

    private float dashForce;


    public DashAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_DashAttack stateData)
        : base(entity, stateMachine, animBoolName, attackPosition)
    {
        this.stateData = stateData;
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();

        chargetime = Time.time;
        attackted = false;

        dashForce = stateData.dashforce_A;

        dashAttakFaze = 0;
        //대미지 밑 포지션(넉백용)
        attackDetails.damageAmount = stateData.attackDamage;
        attackDetails.position = entity.transform.position;
        entity.SetVelocity(0f);//이동멈춤
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

        switch (dashAttakFaze)
        {
            case 0:
                entity.SetVelocity(0);
                if (Time.time > chargetime + stateData.dashChargeTime)
                {
                    dashAttakFaze = 2;
                    dashTimeLeft = Time.time;
                    entity.anim.SetBool("dashAttack_2", true);
                    //Debug.Log("1");
                }
                break;
            case 2:
                if (Time.time > dashTimeLeft + stateData.dashtime)
                {
                    dashAttakFaze = 3;
                    dashafterTimeLeft = Time.time;
                    entity.SetVelocity(0);
                    entity.anim.SetBool("dashAttack_2", false);
                    // Debug.Log("3");
                }
                else
                {
                    //dashForce = Mathf.Lerp(dashForce,stateData.dashforce_B,stateData.lerp);
                    entity.SetVelocity(dashForce);
                    if (Time.time / dashTimeLeft + stateData.dashtime > 0.7f)
                    {
                        dashForce = Mathf.Lerp(dashForce, stateData.dashforce_B, stateData.lerp);
                    }
                }
                break;
            case 3:
                entity.SetVelocity(0);
                if (Time.time > dashafterTimeLeft + stateData.dashAfterTime)
                {
                    // Debug.Log("4");
                    dashAttakFaze = 4;
                    entity.SetVelocity(0);
                }
                break;
            case 4:
                entity.SetVelocity(0);
                // Debug.Log("5");
                isAttacking = false; //끝.
                break;

            default:
                entity.SetVelocity(0);
                break;
        }


    }




    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }



    //닿았으면.
    public override void TriggerAttack()
    {
        base.TriggerAttack();

        if (!attackted && dashAttakFaze == 2)
        {
            attackted = true;
            //충돌된 오브젝트
            Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPosition.position, stateData.attackRadius, stateData.whatIsPlayer);

            attackDetails.damageAmount = stateData.attackDamage; // 0번 인자에 대미지
            attackDetails.position = entity.transform.position; //1번 인자에 X위치

            foreach (Collider2D collider in detectedObjects)
            {
                collider.transform.SendMessage("Damage", attackDetails);
            }
        }
    }



}
