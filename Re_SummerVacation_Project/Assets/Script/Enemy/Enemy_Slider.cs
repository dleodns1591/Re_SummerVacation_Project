using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Slider : MonoBehaviour
{
    public Vector3 Distance = Vector3.down * 35f;
    private Transform TargetTransform;
    private RectTransform rectTransform;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetUp(Transform Target)
    {
        TargetTransform = Target;
        rectTransform = GetComponent<RectTransform>();
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
