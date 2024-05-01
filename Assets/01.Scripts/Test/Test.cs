using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test
{

    public class Test : MonoBehaviour
    {
        [SerializeField] private RectTransform _rect; //Canvas

        [SerializeField] private RectTransform _target; //Mover


        private RectTransform _myRect;

        private RectTransform _rectParent; //Mover에 따로 부모가 있다면

        private void Awake()
        {
            _myRect = GetComponent<RectTransform>();

            _rectParent = _rect.parent as RectTransform;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                Vector3 pos = _myRect.InverseTransformPoint(_rect.position);

                _target.anchoredPosition = pos;
            }
        }
    }

}