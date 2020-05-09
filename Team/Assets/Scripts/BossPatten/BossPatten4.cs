using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatten4 : MonoBehaviour
{
    [SerializeField]
    private int downSpeed;
    [SerializeField]
    private int speed;
    private bool Down =true;
    Vector3 position;
 
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Delay1());
    }
    void HandDown()
    {
        if(Down)
        transform.Translate(Vector3.down * downSpeed * Time.deltaTime);
        if (transform.position.y < -2.82)
            Down = false;
    }
    void HandRight()
    {      
       transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    IEnumerator Delay1()
    {
        yield return new WaitForSeconds(2f);
        HandDown();
        yield return new WaitForSeconds(2f);
        HandRight();
    }
 
}
