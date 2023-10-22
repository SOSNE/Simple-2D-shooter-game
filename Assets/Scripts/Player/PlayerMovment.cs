using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float speed;
    private Vector2 _movment;
    

    void Update()
    {
        _movment.x = Input.GetAxis("Horizontal");
        _movment.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + _movment * (speed * Time.fixedDeltaTime));
    }
}