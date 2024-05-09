using HS;
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
        [SerializeField] public Card _card;
        public CropInven _cropInven;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_clickToDescription)
            {
                _card.SetDescription(currentCard.description);
            }

            if (_isSeed)
            {
                if (CropManager.Instance.CanPlanting == false) return;

                DragAndDropManager.Instance.SetCard(currentCard);
            }
            else
            {
                var crop = CropManager.Instance.cropUtility.cardToCropDataDic[currentCard];
                DragAndDropManager.Instance.SetImage(crop.sprite);
                _cropInven = transform.parent.GetComponentInParent<CropInven>();
                DragAndDropManager.Instance.dragObject._cropInven = _cropInven;
            }
        }
    }

}