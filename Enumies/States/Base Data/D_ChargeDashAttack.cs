using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newmeleeAttackStateData", menuName = "Data/State Data/Melee Attack State")]
public class D_MeleeAttack : ScriptableObject
{

    
    public float attackRadius = 0.5f;
    public float attackDamage = 10f;


    public float dashChargeTime = 3f;


    //트리거에쓸 공격 레이어 마스크
    public LayerMask whatIsPlayer;

}
