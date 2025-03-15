using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    Vector2 moveDir;
    public float speed;

    private void Awake()
    {
        
    }

    void Update()
    {
        SetDir();
    }

    private void FixedUpdate()
    {
        transform.position += (new Vector3(moveDir.x, moveDir.y)).normalized * Time.fixedDeltaTime * speed;
    }

    private void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    private void SetDir()
    {
        moveDir = (GameManager.Instance.Player.transform.position - this.transform.position).normalized;
    }
}
