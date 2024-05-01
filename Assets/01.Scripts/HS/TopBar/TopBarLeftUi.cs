using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HS
{
    public class TopBarLeftUi : MonoBehaviour
    {
        [SerializeField] private string[] _weather;
        [SerializeField] private Sprite[] _weatherIcon;
        [SerializeField] private TextMeshProUGUI _weatherText;
        [SerializeField] private Image _weatherImage;

        public void ChangeWeather()
        {
            int num = Random.Range(0, 2);
            _weatherText.text = _weather[num];
            _weatherImage.sprite = _weatherIcon[num];
        }

    }
}