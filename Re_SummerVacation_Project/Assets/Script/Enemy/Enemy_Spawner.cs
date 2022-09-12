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

    [Header("眉仿")]
    public GameObject SliderHP_Prefab;
    public Transform Canvas_Transform;

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
                    GameObject Enemy_Clone_01 = Instantiate(Enemy_Kind[2], new Vector3(PositionX, Enemy_StageData.LimitMax.y + 1.0f, 0.0f), Quaternion.identity);
                    Sapwn_EnemySlider(Enemy_Clone_01);
                    break;


                case Enemy_Spawn.Onion:
                    GameObject Enemy_Clone_02 = Instantiate(Enemy_Kind[3], new Vector3(PositionX, Enemy_StageData.LimitMax.y + 1.0f, 0.0f), Quaternion.identity);
                    Sapwn_EnemySlider(Enemy_Clone_02);
                    break;


                case Enemy_Spawn.Snake:
                    GameObject Enemy_Clone_03 = Instantiate(Enemy_Kind[4], new Vector3(PositionX, Enemy_StageData.LimitMax.y + 1.0f, 0.0f), Quaternion.identity);
                    Sapwn_EnemySlider(Enemy_Clone_03);
                    break;


                case Enemy_Spawn.Wolf:
                    GameObject Enemy_Clone_04 = Instantiate(Enemy_Kind[5], new Vector3(PositionX, Enemy_StageData.LimitMax.y + 1.0f, 0.0f), Quaternion.identity);
                    Sapwn_EnemySlider(Enemy_Clone_04);
                    break;


                case Enemy_Spawn.Rabbit:
                    GameObject WarningLine = Instantiate(Enemy_Kind[1], new Vector3(PositionX, 0, 0), Quaternion.identity);

                    yield return new WaitForSeconds(1.0f);

                    DOTween.Kill(Line.Inst.Warning_Line);
                    Destroy(WarningLine);

                    Instantiate(Enemy_Kind[0], new Vector3(PositionX, Enemy_StageData.LimitMax.y + 1.0f, 0.0f), Quaternion.identity);
                    float SpawnTime = Random.Range(Min_SpawnTime, Max_SpawnTime);
                    break;
            }
            yield return new WaitForSeconds(Spawn_Time);
        }

    }

    private void Sapwn_EnemySlider(GameObject Enemy)
    {
        GameObject Slider_Clone = Instantiate(SliderHP_Prefab);
        Slider_Clone.transform.SetParent(Canvas_Transform);
        Slider_Clone.transform.localScale = Vector3.one;
        Slider_Clone.GetComponent<Enemy_Slider>().SetUp(Enemy.transform);
    }
}
