using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    [Header("메테오 이동")]
    public float Meteorite_Speed;
    public Vector3 Meteorite_Direction = Vector3.zero;

    [Header("메테오 생성")]
    public Stage_Data Meteorite_StageData;


    void Start()
    {

    }

    void Update()
    {
        transform.position += Meteorite_Direction * Meteorite_Speed * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction) => Meteorite_Direction = direction;
}
