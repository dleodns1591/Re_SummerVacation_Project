using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Move_Speed = 0.0f;
    public Vector3 MoveDirection = Vector3.zero;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += MoveDirection * Move_Speed * Time.deltaTime;
        Player_Controller();
    }

    public void MoveTo(Vector3 direction) => MoveDirection = direction;

    public void Player_Controller()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        MoveTo(new Vector3(x, y, 0));
    }
}
