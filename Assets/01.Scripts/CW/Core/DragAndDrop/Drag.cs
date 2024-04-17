using HS;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CW
{
    public class Drag : MonoBehaviour, IPointerDownHandler
    {
        public CardSO currentCard;
        private GameObject _crop;
        [SerializeField] private bool _isSeed = false;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_isSeed == false)//UI
            {
                var crop = CropManager.Instance.cropUtility.cardToCropDataDic[currentCard];
                DragAndDropManager.Instance.SetImage(crop.sprite);

                DragAndDropManager.Instance.dragObject.cropCount 
                    = transform.parent.GetComponentInParent<CropInven>()._fruitCount;
                DragAndDropManager.Instance.dragObject.cropPrice 
                    = transform.parent.GetComponentInParent<CropInven>()._currentPrice;
            }
            else
            {
                DragAndDropManager.Instance.SetImage(currentCard);
            }
            DragAndDropManager.Instance.IsSeed = _isSeed;
        }
    }

}