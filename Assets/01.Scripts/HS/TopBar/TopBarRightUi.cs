using TMPro;
using UnityEngine;

namespace HS
{
    public class TopBarRightUi : MonoBehaviour
    {
        private TextMeshProUGUI _creditText;
        [SerializeField] private int credit;

        private void Awake()
        {
            _creditText = transform.Find("Credit").GetComponent<TextMeshProUGUI>();
            _creditText.text = credit.ToString();
        }

        public void ChangeCredit(int value)
        {
            credit += value;
            _creditText.text = credit.ToString();
        }
    }
}