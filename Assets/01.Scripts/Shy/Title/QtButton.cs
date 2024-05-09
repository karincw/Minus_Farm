using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class QtButton : MonoBehaviour
{
    [SerializeField] GameObject tmp;
    [SerializeField] Transform pos;
    Vector3 lastPos;

    private void Awake()
    {
        lastPos = transform.position;
        tmp.transform.DOScale(Vector3.zero, 0f);
    }

    private void OnMouseEnter()
    {
        if (TitleUIManager.TextFin)
            transform.DOMove(pos.position, 1f).OnStart(()=>tmp.transform.DOScale(new Vector3(1,1), 0.7f));
    }

    private void OnMouseDown()
    {
        //게임 나가기 코드
        if (TitleUIManager.TextFin)
            Application.Quit();
    }

    private void OnMouseExit()
    {
        if (TitleUIManager.TextFin)
            transform.DOMove(lastPos, 1f).OnStart(() => tmp.transform.DOScale(Vector3.zero, 0.7f));
    }
}
