using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CW
{

    public class StandCard : MonoBehaviour
    {
        [SerializeField] Card[] _standImages;
        [SerializeField] TextMeshProUGUI _descriptionText;
        private CardInven _cardInven;

        private void Awake()
        {
            _cardInven = FindObjectOfType<CardInven>();

        }


        private void Update()
        {
            CropManager manager = CropManager.Instance;
            Transform trm = _standImages[0].transform.parent.Find("CooltimeViewer");
            if (manager.CanPlanting == false)
            {
                float current = manager.Cooldown / manager.Cooltime;
                trm.GetComponent<Image>().fillAmount = current;
            }
            else
            {
                trm.GetComponent<Image>().fillAmount = 0;
            }

#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.U))
            {
                UpdateCard();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Stand();
            }
#endif
        }


        [ContextMenu("Stand")]
        public void Stand()
        {
            _cardInven.Suffle();

            int curCardSize = _cardInven.inventory.Count - 1;
            for (int i = 0; i < 6; i++)
            {
                int cur = curCardSize - i;
                CardSO nextCard = _cardInven.inventory[cur];
                _standImages[i].CurrentCard = nextCard;
                _cardInven.inventory.RemoveAt(cur);
            }
        }

        [ContextMenu("Update")]
        public void UpdateCard()
        {
            for (int i = 0; i < 6; i++)
            {
                int nextIdx = i + 1;
                CardSO nextCard = null;
                if (nextIdx < _standImages.Length)
                {
                    if (_standImages[nextIdx] != null)
                    {
                        nextCard = _standImages[nextIdx].CurrentCard;
                    }
                    else if (_cardInven.inventory.Count > 0)
                    {
                        int cur = _cardInven.inventory.Count - 1;
                        nextCard = _cardInven.inventory[cur];
                        _cardInven.inventory.RemoveAt(cur);
                    }

                    _standImages[i].CurrentCard = nextCard;
                }
                else
                {
                    if (nextCard == null && _cardInven.inventory.Count > 0)
                    {
                        int cur = _cardInven.inventory.Count - 1;
                        nextCard = _cardInven.inventory[cur];
                        _cardInven.inventory.RemoveAt(cur);
                    }

                    _standImages[i].CurrentCard = nextCard;
                }

            }

        }

    }

}