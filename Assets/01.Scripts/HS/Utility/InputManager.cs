using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject SettingUi;

    private bool _isOnSetting;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_isOnSetting)
            {
                SettingUi.SetActive(true);
                _isOnSetting = true;
            }
            else
            {
                SettingUi.SetActive(false);
                _isOnSetting = false;
            }
        }
    }
}
