using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newLandAttackStateData", menuName = "Data/State Data/Land Attack State")]
public class D_LandAttackState : ScriptableObject
{
    public float attackRadius = 0.5f;
    public float attackDamage = 10f;



    //트리거에쓸 공격 레이어 마스크
    public LayerMask whatIsPlayer;
}
