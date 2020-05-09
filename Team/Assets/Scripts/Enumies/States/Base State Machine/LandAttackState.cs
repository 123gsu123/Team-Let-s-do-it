using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandAttackState : AttackState
{

    D_LandAttackState stateData;

    private float chargetime;

    private bool attackted;

    protected AttackDetails attackDetails;
    private int landAttakFaze;

    public LandAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform LandattackPosition, D_LandAttackState stateData)
        : base(entity, stateMachine, animBoolName, LandattackPosition)
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
        landAttakFaze = 0;
        attackted = false;
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

        isAttacking = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //switch (landAttakFaze)
        //{
        //    //차징 대기?
        //    case 0:

        //        break;
        //    case 1:
        //        break;
        //    case 2:
        //        break;
        //    case 3:
        //        break;
        //    case 4:
        //        break;
        //    default:
        //        break;
        //}
    }


    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }


    public override void TriggerAttack()
    {
        base.TriggerAttack();

        if (!attackted && landAttakFaze == 2)
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
