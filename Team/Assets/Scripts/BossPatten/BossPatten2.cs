using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatten2 : MonoBehaviour
{
    [SerializeField]
    private int speed;


     void Start()
     {

     }

     void Update()
     {
        StartCoroutine(Delay());
    }

    void FallDown()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
    
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.5f);
        FallDown();
    }
}

