using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="newEntityData", menuName = "Data/Entity Data/Base Data")]
public class D_Entity : ScriptableObject
{
    public float hp = 100f;

    public float wallCheckDistance = 0.4f;
    public float ledgeCheckDistance = 0.4f;
    public float findDistance = 0.4f;

    public float maxAgroDistance = 4f;
    public float minAgroDistance = 3f;

    public float closeRangeActionDistance = 1f;


    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;

}
