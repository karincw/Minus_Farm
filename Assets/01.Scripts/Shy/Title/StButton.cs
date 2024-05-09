using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class StButton : MonoBehaviour
{
    [SerializeField] Transform pos;
    Vector3 lastPos;
    Vector3 lastRotate;

    [SerializeField] GameObject tit;
    [SerializeField] GameObject poong;
    [SerializeField] GameObject qui;

    bool animefinish = false;
    private void Start()
    {
        lastPos = transform.position;
        lastRotate = new Vector3(0, 0, -27);
    }

    private void OnMouseEnter()
    {
        if (TitleUIManager.TextFin)
            transform.DOMove(pos.position, 1f).OnStart(()=>transform.DORotate(Vector3.zero, 1f)).OnComplete(()=>animefinish = true);      
    }

    private void OnMouseDown()
    {
        if (TitleUIManager.TextFin && animefinish) Fin();
    }

    void Fin()
    {
        TitleUIManager.TextFin = false;
        animefinish = false;
        qui.transform.DOLocalMoveX(-1500, 1f);
        tit.transform.DOMove(tit.transform.position, 0.3f).OnComplete(() => tit.transform.DOLocalMoveY(1300, 1f).
        OnStart(()=>poong.transform.DOLocalMoveY(1300, 1f)));

        transform.DOMove(transform.position, 1.2f).OnComplete(()=>transform.DOLocalMoveY(-1500, 1f).OnComplete(() => SceneManager.LoadScene("Shy_Story")));
    }

    private void OnMouseExit()
    {
        if (TitleUIManager.TextFin)
            transform.DOMove(lastPos, 1f).OnStart(() => transform.DORotate(lastRotate, 1f));
    }
}
