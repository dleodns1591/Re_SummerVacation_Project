using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("이동 속도 / 방향")]
    public float Enemy_Speed;
    public Vector3 Enemy_Direction = Vector3.zero;

    [Header("공격력")]
    public int Attack;

    [Header("스코어")]
    public int Score_Point;

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
        {
            Player.Inst.TakeDamage(Attack);

            if (this.CompareTag("Enemy"))
            {
                GameManager.Inst.Score += Score_Point;
                Destroy(this.gameObject);
            }
        }
    }
}
