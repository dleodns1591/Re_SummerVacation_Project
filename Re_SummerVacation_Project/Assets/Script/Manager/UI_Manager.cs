using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    public TextMeshProUGUI Score_Text;
    public TextMeshProUGUI EnemyDie_Text;

    void Start()
    {
        
    }

    void Update()
    {
        Score_Text.text = "Score : " + GameManager.Inst.Score;
        EnemyDie_Text.text = "EnemyDie : " + GameManager.Inst.EnemyDie_Score;
    }
}
