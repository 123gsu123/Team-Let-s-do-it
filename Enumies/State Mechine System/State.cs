using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    protected FiniteStateMachine stateMachine;
    protected Entity entity;

    public float startTime;//시작 시간.

    protected bool inRange;

    protected string animBoolName;
    
    //생성자
    public State(Entity entity, FiniteStateMachine stateMachine, string animBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
        DoCheck();
    }

    //입장
    public virtual void Enter()
    {
        startTime = Time.time; //시작타임 .
        entity.anim.SetBool(animBoolName, true);
    }

    //퇴장
    public virtual void Exit()
    {
        entity.anim.SetBool(animBoolName, false);
    }

    //업데이트
    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicUpdate()
    {
        DoCheck();
    }

    public virtual void DoCheck()
    {

    }
    
}
