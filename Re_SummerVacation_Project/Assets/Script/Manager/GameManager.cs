using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Inst { get; private set; }

    [Header("�÷��̾� ü��")]
    public float Player_MaxHP;
    public float Player_CurrentHP;

    [Header("���ھ�")]
    public float Score;
    public float EnemyDie_Score;

    void Start()
    {

    }

    void Update()
    {
        Key();
    }

    private void Awake()
    {
        Player_CurrentHP = Player_MaxHP;

        if (Score <= 0)
            Score = 0;

        if (Inst == null)
        {
            Inst = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private void Key()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // �Ͻ�����
        }
    }
}
