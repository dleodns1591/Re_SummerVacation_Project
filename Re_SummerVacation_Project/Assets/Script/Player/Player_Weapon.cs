using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Weapon : MonoBehaviour
{
    public float Weapon_Speed;
    public Vector3 Weapon_Direction = Vector3.zero;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Weapon_Direction * Weapon_Speed * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction) => Weapon_Direction = direction;
}
