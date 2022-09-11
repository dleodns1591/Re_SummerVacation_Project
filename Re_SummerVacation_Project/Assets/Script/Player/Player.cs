using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Inst { get; private set; }


    [Header("이동")]
    public Stage_Data StageData;
    public float Move_Speed = 0.0f;
    public Vector3 MoveDirection = Vector3.zero;

    [Header("공격")]
    public GameObject Weapon_Prefab;
    public float Weapon_Speed = 0.2f;

    [Header("충돌")]
    public SpriteRenderer Player_Fade;
    public CircleCollider2D circleCollider2D;

    [Header("체력")]
    public Slider HP_Slider;

    void Start()
    {

    }

    void Update()
    {
        Player_HP();
        Player_Controller();
        transform.position += MoveDirection * Move_Speed * Time.deltaTime;
    }
    public void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, StageData.LimitMin.x, StageData.LimitMax.x),
                                         Mathf.Clamp(transform.position.y, StageData.LimitMin.y, StageData.LimitMax.y));
    }

    private void Awake() => Inst = this;

    public void MoveTo(Vector3 direction) => MoveDirection = direction;

    public void Player_Controller()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        MoveTo(new Vector3(x, y, 0));

        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(Weapon_Instantiate());
    }

    public void TakeDamage(float Damage)
    {
        GameManager.Inst.Player_CurrentHP -= Damage;
        StartCoroutine(Fade_On());

        if (GameManager.Inst.Player_CurrentHP <= 0)
        {
            // 플레이어 죽음 처리
        }
    }

    public void Player_HP()
    {
        HP_Slider.value = GameManager.Inst.Player_CurrentHP / GameManager.Inst.Player_MaxHP;
    }

    #region 공격무기 소환

    private IEnumerator Weapon_Instantiate()
    {
        Instantiate(Weapon_Prefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(Weapon_Speed);
    }
    #endregion

    #region 무적 모션
    public IEnumerator Fade_On()
    {
        circleCollider2D.enabled = false;
        for (int i = 0; i <= 2; i++)
        {
            Player_Fade.DOFade(0.5f, 0.5f);
            yield return new WaitForSeconds(0.5f);
            Player_Fade.DOFade(1f, 0.5f);
        }
        circleCollider2D.enabled = true;
    }
    #endregion
}
