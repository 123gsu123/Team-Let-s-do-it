using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet2 : MonoBehaviour
{
    Transform Player;
    Vector2 PlayerPos;
    Rigidbody2D rigid;
    public float speed;
    bool right = true;
   Vector2 dir;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        Right();
        yield return new WaitForSeconds(4f);
        right = false;
        Follow();
        yield return new WaitForSeconds(7f);
        Destroy(gameObject);
    }
    void Right()
    {
        if(right)
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    void Follow()
    {
        dir = Player.transform.position - transform.position;
        rigid.AddForce(dir.normalized * speed, ForceMode2D.Impulse);  
    }
}
