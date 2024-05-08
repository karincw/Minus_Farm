using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    private Slider _slider;
    [SerializeField] private AudioMixer _masterMixer;

    private void Awake()
    {
        _slider = transform.Find("Slider").GetComponent<Slider>();
    }

    public void AudioControl()
    {
        float sound = _slider.value;

        if (sound == -40f) _masterMixer.SetFloat("BGM", -80);
        else
        {
            _masterMixer.SetFloat("BGM", sound);
        }
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void TitleButton()
    {
        //SceneManager.LoadScene("¹¹½Ã±â ¾À");
    }
    
    
}
