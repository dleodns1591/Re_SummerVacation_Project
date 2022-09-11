using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    public TextMeshProUGUI Score_Text;

    void Start()
    {
        
    }

    void Update()
    {
        Score_Text.text = "Score : " + GameManager.Inst.Score;
    }
}
