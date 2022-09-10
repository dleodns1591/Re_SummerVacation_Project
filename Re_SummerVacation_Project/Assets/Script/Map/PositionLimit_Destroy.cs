using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionLimit_Destroy : MonoBehaviour
{
    public Stage_Data StageData;
    private float Destroy_Weight = 2f;

    private void Update()
    {
        Position_Limit();
    }

    public void Position_Limit()
    {
        if (transform.position.y < StageData.LimitMin.y - Destroy_Weight ||
            transform.position.y > StageData.LimitMax.y + Destroy_Weight ||
            transform.position.x < StageData.LimitMin.x - Destroy_Weight ||
            transform.position.x > StageData.LimitMax.x + Destroy_Weight)
            Destroy(this.gameObject);
    }
}
