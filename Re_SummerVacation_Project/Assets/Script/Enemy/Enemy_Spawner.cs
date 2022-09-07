using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    [Header("�� ����")]
    public Stage_Data StageData; // �� ������ ���� ũ��
    public GameObject Enemy_Prefab;
    public float Spawn_Time; // ���� �ֱ�

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void Awake()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            float PositionX = Random.Range(StageData.LimitMin.x, StageData.LimitMax.x);
            Instantiate(Enemy_Prefab, new Vector3(PositionX, StageData.LimitMax.y + 1.0f, 0.0f), Quaternion.identity);
            yield return new WaitForSeconds(Spawn_Time);
        }
    }
}
