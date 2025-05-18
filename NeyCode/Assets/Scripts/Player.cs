using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]float moveSpeed = 5f;
    [SerializeField] private float turnSpeed = 100f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 pos = GettargetPos(vertical);
        Quaternion rot = GetTagGetRot(horizontal);
        Move(pos);
        Turn(rot);

    }
    private Vector3 GettargetPos(float v)
    {
        Vector3 delta=this.transform.forward*v*moveSpeed*Time.deltaTime;
        Vector3 pos = rb.position+ delta;
        return pos;
    }

    private Quaternion GetTagGetRot(float h)
    {
        Quaternion delta=Quaternion.Euler(0,h*turnSpeed*Time.deltaTime,0);
        Quaternion rot = rb.rotation * delta;
        return rot;
    }

    private void Move(Vector3 pos)
    {
        rb.MovePosition(pos);
    }
    private void Turn(Quaternion rot)
    {
        rb.MoveRotation(rot);
    }
}
