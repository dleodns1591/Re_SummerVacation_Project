using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Enemy_Speed;
    public Vector3 Enemy_Direction = Vector3.zero;

    void Start()
    {

    }

    void Update()
    {
        transform.position += Enemy_Direction * Enemy_Speed * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction) => Enemy_Direction = direction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Destroy(this.gameObject);
    }
}
