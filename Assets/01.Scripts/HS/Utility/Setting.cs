using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    [SerializeField] private Slider _bgSlider;
    [SerializeField] private Slider _imSlider;
    [SerializeField] private AudioMixer _masterMixer;

    public void BGAudioControl()
    {
        float sound = _bgSlider.value;

        if (sound == -40f) _masterMixer.SetFloat("BGM", -80);
        else
        {
            _masterMixer.SetFloat("BGM", sound);
        }
    }
    public void IMAudioControl()
    {
        float sound = _imSlider.value;

        if (sound == -40f) _masterMixer.SetFloat("Impact", -80);
        else
        {
            _masterMixer.SetFloat("Impact", sound);
        }
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void TitleButton()
    {
        SceneManager.LoadScene("Shy_Title");
    }
    
    
}
