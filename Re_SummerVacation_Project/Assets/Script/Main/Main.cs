using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Image GameWay_BackGround;

    void Start()
    {

    }

    void Update()
    {

    }

    public void PlayBtn_Click()
    {
        // 나중에 페이드인아웃 넣어준다.
        SceneManager.LoadScene("1Stage");
    }

    public void GameWayBtn_Click() =>
        GameWay_BackGround.transform.DOLocalMoveX(0, 0.5f).SetEase(Ease.OutQuad);

    public void BackBtn_Click() =>
        GameWay_BackGround.transform.DOLocalMoveX(231, 0.5f).SetEase(Ease.OutQuad);
}
