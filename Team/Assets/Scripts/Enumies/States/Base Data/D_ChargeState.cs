using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newChargeStateData", menuName = "Data/State Data/Charge State")]
public class D_ChargeState : ScriptableObject
{
    //추적 스피드
    public float chargeSpeed = 6f;

    //어택용.
    public float AttakArange;

    //시야밖에 나는 시간, 위 , 아래 등등.
    public float sightOutTime = 3f;
    public float sightUp = 1.5f;
    public float sightDown = 1f;
    
}
