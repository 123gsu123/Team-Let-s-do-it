using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine
{
    public State currentState { get; private set; } // State 한개 가지기.

    public void Initialize(State startingState) //초기화.
    {
        currentState = startingState;
        currentState.Enter();
    }

    public void ChangeState(State newState)
    {
        currentState.Exit();//나가고
        currentState = newState; //세팅하고
        currentState.Enter(); //다시 시작.
    }

    public float getStartTime()
    {
        return currentState.startTime;
    }
}
