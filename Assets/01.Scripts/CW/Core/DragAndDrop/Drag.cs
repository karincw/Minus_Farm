using HS;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CW
{
    public class Drag : MonoBehaviour, IPointerDownHandler
    {
        public CardSO currentCard;
        private GameObject _crop;
        public CropInven _cropInven;
        [SerializeField] private bool _isSeed = false;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_isSeed == false)//UI
            {
                var crop = CropManager.Instance.cropUtility.cardToCropDataDic[currentCard];
                DragAndDropManager.Instance.SetImage(crop.sprite);

                #region
                _cropInven = transform.parent.GetComponentInParent<CropInven>();
                DragAndDropManager.Instance.dragObject._cropInven = _cropInven;
                #endregion
            }
            else
            {
                DragAndDropManager.Instance.SetImage(currentCard);
            }
            DragAndDropManager.Instance.IsSeed = _isSeed;
        }
    }

}