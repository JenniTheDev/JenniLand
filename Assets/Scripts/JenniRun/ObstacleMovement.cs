using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1.0f;
    private Transform cacheTransform;

    public void Awake()
    {
        cacheTransform = transform;
    }

    public void Update()
    {
        Move();
    }

    private void Move()
    {
        cacheTransform.Translate(Time.deltaTime * movementSpeed * Vector2.left);
    }
}