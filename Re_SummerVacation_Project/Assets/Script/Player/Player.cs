using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Stage_Data StageData;
    public float Move_Speed = 0.0f;
    public Vector3 MoveDirection = Vector3.zero;

    [Header("플레이어 공격")]
    public GameObject Weapon_Prefab;
    public float Weapon_Speed = 0.2f;

    void Start()
    {

    }

    void Update()
    {
        transform.position += MoveDirection * Move_Speed * Time.deltaTime;
        Player_Controller();
    }
    public void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, StageData.LimitMin.x, StageData.LimitMax.x),
                                         Mathf.Clamp(transform.position.y, StageData.LimitMin.y, StageData.LimitMax.y));
    }

    public void MoveTo(Vector3 direction) => MoveDirection = direction;

    public void Player_Controller()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        MoveTo(new Vector3(x, y, 0));

        if (Input.GetKeyDown(KeyCode.Z))
            StartCoroutine(Weapon_Instantiate());
    }


    #region 공격무기 소환

    private IEnumerator Weapon_Instantiate()
    {
        Instantiate(Weapon_Prefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(Weapon_Speed);
    }
    #endregion
}
