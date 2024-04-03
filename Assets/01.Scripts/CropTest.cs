using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropTest : MonoBehaviour
{
    private void Start()
    {
        //게임오브젝트가 아닌 UI로 바꿔서 넣어라
        //선한쌤의 전언

        Debug.Log( Camera.main.WorldToScreenPoint(transform.position));


    }
}
