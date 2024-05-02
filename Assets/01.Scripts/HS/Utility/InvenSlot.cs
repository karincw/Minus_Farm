using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HS
{
    public class InvenSlot : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI countText;

        private void ChangeSprite(Sprite sprite)
        {
            image.sprite = sprite;
        }
        
        private void ChangeCount(int count)
        {
            countText.text = count.ToString();
        }
        
        private void ChangeName(string cardName)
        {
            nameText.text = cardName;
        }

        public void SetInvenSlot(int count, string cardName, Sprite sprite)
        {
            ChangeCount(count);
            ChangeName(cardName);
            ChangeSprite(sprite);
        }
    }
}