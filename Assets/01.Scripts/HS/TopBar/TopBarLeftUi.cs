using TMPro;
using UnityEngine;

namespace HS
{
    public class TopBarLeftUi : MonoBehaviour
    {
        [SerializeField] private string[] _weather;
        [SerializeField] private TextMeshProUGUI _weatherText;

        public void ChangeWeather()
        {
            _weatherText.text = _weather[Random.Range(0, 2)];
        }

    }
}