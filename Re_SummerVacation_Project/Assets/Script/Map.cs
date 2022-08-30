using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [Header("배경 이동")]
    public float ScrollRange = 0f;
    public float MoveSpeed = 0f;
    public Transform Target;
    public Vector3 MoveDirection = Vector3.down;
    
    void Start()
    {
        
    }

    void Update()
    {
        BackGround_Move();
    }

    private void BackGround_Move()
    {
        transform.position += MoveDirection * MoveSpeed * Time.deltaTime;

        if (transform.position.y <= -ScrollRange)
            transform.position = Target.position + Vector3.up * ScrollRange;
    }
}
