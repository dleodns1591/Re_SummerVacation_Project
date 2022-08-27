using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlayBtn_Click() => SceneManager.LoadScene("1Stage");

    public void GameWayBtn_Click() => SceneManager.LoadScene("GameWay");

    public void BackBtn_Click() => SceneManager.LoadScene("Main");
}
