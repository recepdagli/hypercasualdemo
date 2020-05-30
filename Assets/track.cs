using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class track : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ball;
    private ParticleSystem ps;
    private ParticleSystem.MainModule ma;
    void Start()
    {
        ball = GameObject.Find("Sphere");
        ps = GetComponent<ParticleSystem>();
        ParticleSystem.MainModule ma = ps.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(ball.transform.position.x,ball.transform.position.y-0.1f,ball.transform.position.z);
        ps.startColor = ball.transform.GetComponent<Renderer>().material.color;
    }
}
