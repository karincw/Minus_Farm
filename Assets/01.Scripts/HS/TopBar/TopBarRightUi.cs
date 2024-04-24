using TMPro;
using UnityEngine;

namespace HS
{
    public class TopBarRightUi : MonoBehaviour
    {
        private TextMeshProUGUI _creditText;
        public int _credit;

        private void Awake()
        {
            _creditText = transform.Find("Credit").GetComponent<TextMeshProUGUI>();
            _creditText.text = _credit.ToString();
        }

        public void ChangeCredit(int value)
        {
            _credit += value;
            _creditText.text = _credit.ToString();
        }
    }
}