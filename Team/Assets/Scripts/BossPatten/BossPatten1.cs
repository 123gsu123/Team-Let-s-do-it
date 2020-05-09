using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatten1 : MonoBehaviour
{
    [SerializeField]
    private int speed;
    

    void Start()
    {
        
    }

    void Update()
    {
        FallDown();
    }

    void FallDown()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
