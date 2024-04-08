using UnityEngine;
using UnityEngine.EventSystems;

namespace CW
{

    public class Drag : MonoBehaviour, IPointerDownHandler
    {
        public CardSO currentCard;

        public void OnPointerDown(PointerEventData eventData)
        {
            DragAndDropManager.Instance.Card = currentCard;
        }
    }

}