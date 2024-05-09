using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class TitleUIManager : MonoBehaviour
{
    [SerializeField] private GameObject titleName;
    [SerializeField] private GameObject startBt;
    [SerializeField] private GameObject poongcha;
    [SerializeField] private RectTransform wing;

    public static bool TextFin = false;

    private void Awake()
    {
        TextFin = false;
        titleName.transform.localScale = Vector3.zero;
        poongcha.transform.localPosition = new Vector3(135, 850, 0);
    }

    private void Start()
    {
        InitTitle();
    }

    private void RotateWing(float z)
    {
        z = wing.rotation.z + z;
        wing.DORotate(new Vector3(0, 0, z), 0.05f).OnComplete(()=>RotateWing(z - 10));
    }
    
    private void InitTitle()
    {
        titleName.transform.DOScale(new Vector3(1, 1), 1f).OnComplete(()=>poongcha.transform.DOLocalMoveY(260, 1).SetEase(Ease.InOutBack).OnComplete(()=> 
        {
            RotateWing(-10);
            TextFin = true;
        }));
    }
}
