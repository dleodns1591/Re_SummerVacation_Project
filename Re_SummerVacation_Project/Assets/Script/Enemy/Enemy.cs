using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    [Header("이동 속도 / 방향")]
    public float Enemy_Speed;
    public Vector3 Enemy_Direction = Vector3.zero;

    [Header("공격력")]
    public int Attack;

    [Header("스코어")]
    public int Score_Point;

    [Header("체력")]
    public float MaxHP;
    public float CurrentHP;

    void Start()
    {

    }

    void Update()
    {
        transform.position += Enemy_Direction * Enemy_Speed * Time.deltaTime;
    }

    private void Awake()
    {
        CurrentHP = MaxHP;
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    public void MoveTo(Vector3 direction) => Enemy_Direction = direction;

    public void TakeDamage(float Damage)
    {
        CurrentHP -= Damage;

        StopCoroutine(Hit_Color());
        StartCoroutine(Hit_Color());

        if (CurrentHP <= 0)
        {
            GameManager.Inst.Score += Score_Point;
            Destroy(this.gameObject);
        }
    }

    private IEnumerator Hit_Color()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        spriteRenderer.color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.Inst.TakeDamage(Attack);
            Destroy(this.gameObject);

            if (this.CompareTag("Meteorite"))
                GameManager.Inst.Score += Score_Point;
        }
    }
}
