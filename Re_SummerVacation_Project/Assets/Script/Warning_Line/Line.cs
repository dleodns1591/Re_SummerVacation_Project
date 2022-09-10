using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Line : MonoBehaviour
{
    public SpriteRenderer Warning_Line;


    void Start()
    {
        StartCoroutine(Coroutine_Line_1());
    }
    
    void Update()
    {

    }

    private IEnumerator Coroutine_Line_1()
    {
        Warning_Line.DOFade(0f, 0.3f);
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(Coroutine_Line_2());
    }

    private IEnumerator Coroutine_Line_2()
    {
        Warning_Line.DOFade(1f, 0.3f);
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(Coroutine_Line_1());
    }
}
