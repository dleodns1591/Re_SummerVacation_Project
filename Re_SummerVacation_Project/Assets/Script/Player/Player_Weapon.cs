using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Weapon : MonoBehaviour
{
    [Header("�̵� �ӵ� / ����")]
    public float Weapon_Speed;
    public Vector3 Weapon_Direction = Vector3.zero;

    [Header("���ݷ�")]
    public int Attack;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Weapon_Direction * Weapon_Speed * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction) => Weapon_Direction = direction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(Attack);
            Destroy(this.gameObject);
        }
            
    }
}
