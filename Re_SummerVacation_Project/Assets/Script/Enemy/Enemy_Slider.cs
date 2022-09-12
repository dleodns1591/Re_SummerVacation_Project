using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Slider : MonoBehaviour
{
    public Vector3 Distance = Vector3.down * 35f;
    private Transform TargetTransform;
    private RectTransform rectTransform;

    private Enemy enemy;
    private Slider Enemy_HPSlider;

    void Start()
    {
        
    }

    void Update()
    {
        Enemy_HPSlider.value = enemy.CurrentHP / enemy.MaxHP;
    }

    public void T_SetUp(Transform Target)
    {
        TargetTransform = Target;
        rectTransform = GetComponent<RectTransform>();
    }

    public void HP_SetUp(Enemy EnemyHP)
    {
        this.enemy = EnemyHP;
        Enemy_HPSlider = GetComponent<Slider>();
    }

    private void LateUpdate()
    {
        if (TargetTransform == null)
        {
            Destroy(this.gameObject);
            return;
        }

        Vector3 ScreenPosition = Camera.main.WorldToScreenPoint(TargetTransform.position);
        rectTransform.position = ScreenPosition + Distance;
    }
}
