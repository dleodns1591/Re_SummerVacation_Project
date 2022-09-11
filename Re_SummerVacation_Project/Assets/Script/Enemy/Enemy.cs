using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("�̵� �ӵ� / ����")]
    public float Enemy_Speed;
    public Vector3 Enemy_Direction = Vector3.zero;

    [Header("���ݷ�")]
    public int Attack;

    [Header("���ھ�")]
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
