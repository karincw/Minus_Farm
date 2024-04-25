using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CW
{

    public class Drag : MonoBehaviour, IPointerDownHandler
    {
        public CardSO currentCard;
        [SerializeField] private bool _isSeed = false;

        [Header("ClickToDescription")]
        [SerializeField] private bool _clickToDescription = false;
        [SerializeField] private Card _card;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_clickToDescription)
            {
                _card.SetDescription(currentCard.description);
            }

            if (_isSeed)
            {
                DragAndDropManager.Instance.SetCard(currentCard);
            }
            else
            {
                var crop = CropManager.Instance.cropUtility.cardToCropDataDic[currentCard];
                DragAndDropManager.Instance.SetImage(crop.sprite);
            }
        }
    }

}