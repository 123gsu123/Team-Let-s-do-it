using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMoveStateData", menuName = "Data/State Data/Move State")]
public class D_MoveState : ScriptableObject // ScriptableObject : Perfab 사용시에 유용
{
    public float movementSpeed = 3f;
    public float minMoveTime = 0.5f;//기다릴지 .
    public float maxMoveTime = 4;

    public float chaseTime = 2f;
}
