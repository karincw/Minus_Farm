using TMPro;
using UnityEngine;

namespace HS
{
    public class TopBarRightUi : MonoBehaviour
    {
        private TextMeshProUGUI _creditText;
        private TextMeshProUGUI _debtText;
        public int debt;
        public int credit;
        private int _count;

        private void Awake()
        {
            _debtText = transform.Find("Debt").GetComponent<TextMeshProUGUI>();
            _creditText = transform.Find("Credit").GetComponent<TextMeshProUGUI>();
            _creditText.text = $"{credit}G";
        }

        public void ChangeCredit(int value)
        {
            credit += value;
            _creditText.text = $"{credit}G";
        }

        public void DebtCancel()
        {
            credit -= debt;
            
            debt *= 2;
            //계산식 추가 
            if (debt < 0) debt = 1;

            _creditText.text = $"{credit}G";
            _debtText.text = $"-{debt}G";
        }

        public void FailureCheck()
        {
            if (credit < 0)
            {
                _count++;
                if (_count >= 7)
                {
                    //SceneManager.LoadScene("");
                }
            }
            else
            {
                _count = 0;
            }
        }
    }
}