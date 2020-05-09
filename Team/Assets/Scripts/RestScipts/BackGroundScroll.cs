using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    private float length;
    private float startpos;
    private float proPos;

    public GameObject m_camera;
    public float followCamEffect;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        proPos = startpos;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float a;
        a = proPos - m_camera.transform.position.x;
        float temp = (m_camera.transform.position.x * (1 - followCamEffect));

        float dist = (a * followCamEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length)
           startpos += length;
        else if (temp < startpos - length)
            startpos -= length;

    }
}
