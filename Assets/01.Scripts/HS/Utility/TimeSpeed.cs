using System;
using UnityEngine;

namespace HS
{
    public class TimeSpeed : MonoBehaviour
    {
        private TopBarMiddleUi _time;
        [SerializeField] private float maxSpeed;

        private void Awake()
        {
            _time = GameObject.Find("Middle").GetComponent<TopBarMiddleUi>();
        }

        public void Acceleration(bool isButtonDown)
        {
            _time.timeSpeed = isButtonDown ? maxSpeed : 1;
        }
    }
}