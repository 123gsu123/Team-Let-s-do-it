using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatten5 : MonoBehaviour
{
    public GameObject Bullet;
    public int  Count;
    void Start()
    {
        InvokeRepeating("Fire", 0, 2f);
    }
   
    void Update()
    {
        
    }

    void Fire()
    {
        if (Count != 0)
        {
            GameObject bul0 = Instantiate(Bullet, transform.position, Quaternion.identity);
            Count--;
        }
    }
}
