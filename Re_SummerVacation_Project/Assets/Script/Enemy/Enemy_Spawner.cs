using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Enemy_Spawner : MonoBehaviour
{
    public enum Enemy_Spawn
    {
        Rabbit,
        AppleMonster,
        Onion,
        Snake,
        Wolf
    }

    public Enemy_Spawn enemy_Spawn;
    public List<GameObject> Enemy_Kind = new List<GameObject>();

    [Header("利 积己")]
    public Stage_Data Enemy_StageData; // 利 积己阑 困茄 农扁
    public float Spawn_Time; // 积己 林扁

    [Header("皋抛坷 积己")]
    public float Min_SpawnTime = 1f;
    public float Max_SpawnTime = 4f;

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
            float PositionX = Random.Range(Enemy_StageData.LimitMin.x, Enemy_StageData.LimitMax.x);
            switch (enemy_Spawn)
            {
                case Enemy_Spawn.AppleMonster:
                    Instantiate(Enemy_Kind[2], new Vector3(PositionX, Enemy_StageData.LimitMax.y + 1.0f, 0.0f), Quaternion.identity);
                    break;


                case Enemy_Spawn.Onion:
                    Instantiate(Enemy_Kind[3], new Vector3(PositionX, Enemy_StageData.LimitMax.y + 1.0f, 0.0f), Quaternion.identity);
                    break;


                case Enemy_Spawn.Snake:
                    Instantiate(Enemy_Kind[4], new Vector3(PositionX, Enemy_StageData.LimitMax.y + 1.0f, 0.0f), Quaternion.identity);
                    break;


                case Enemy_Spawn.Wolf:
                    Instantiate(Enemy_Kind[5], new Vector3(PositionX, Enemy_StageData.LimitMax.y + 1.0f, 0.0f), Quaternion.identity);
                    break;


                case Enemy_Spawn.Rabbit:
                    GameObject WarningLine = Instantiate(Enemy_Kind[1], new Vector3(PositionX, 0, 0), Quaternion.identity);

                    yield return new WaitForSeconds(1.0f);

                    DOTween.KillAll();
                    Destroy(WarningLine);

                    Instantiate(Enemy_Kind[0], new Vector3(PositionX, Enemy_StageData.LimitMax.y + 1.0f, 0.0f), Quaternion.identity);
                    float SpawnTime = Random.Range(Min_SpawnTime, Max_SpawnTime);
                    break;
            }
            yield return new WaitForSeconds(Spawn_Time);
        }

    }
}
