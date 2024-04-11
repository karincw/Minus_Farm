using UnityEngine;
using UnityEngine.EventSystems;

namespace CW
{

    public class Drag : MonoBehaviour, IPointerDownHandler
    {
        public CardSO currentCard;
        [SerializeField] private bool _isSeed = false;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_isSeed == false)
            {
                var crop = CropManager.Instance.cropUtility.cardToCropDataDic[currentCard];
                DragAndDropManager.Instance.SetImage(crop.sprite);
            }
            else
            {
                DragAndDropManager.Instance.SetImage(currentCard);
            }
            DragAndDropManager.Instance.IsSeed = _isSeed;
        }
    }

}