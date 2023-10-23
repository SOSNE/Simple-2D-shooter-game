using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float speed;
    private Vector2 _movment;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _movment.x = Input.GetAxis("Horizontal");
        _movment.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rb.velocity = _movment * speed;
    }
}