using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newdashAttackStateData", menuName = "Data/State Data/Dash Attack State")]
public class D_DashAttack : ScriptableObject
{

    
    public float attackRadius = 0.5f;
    public float attackDamage = 10f;



    public float dashChargeTime = 30f;


   public float dashtime = 3f;
   public float dashAfterTime = 1f;


    public float lerp = 0.3f;
    public float dashforce_A = 15f;
    public float dashforce_B = 10f;


    //트리거에쓸 공격 레이어 마스크
    public LayerMask whatIsPlayer;
}
