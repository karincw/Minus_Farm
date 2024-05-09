using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject SettingUi;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SettingUi.SetActive(SettingUi.activeInHierarchy == true ? false : true);
        }
    }
}
