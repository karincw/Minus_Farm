using UnityEngine;
using UnityEngine.Tilemaps;

namespace CW
{
    public class DragAndDrop : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _tileHalfSize;
        [SerializeField] private LayerMask _dropLayer;
        [SerializeField] private Tilemap _tileMap;
        CardSO currentCard;

        private void Update()
        {
            currentCard = DragAndDropManager.Instance.Card;
            if (currentCard != null && Input.GetMouseButtonUp(0))
            {
                DragAndDropManager.Instance.Card = null;
                bool isHit = Physics2D.OverlapCircle(transform.position, _tileHalfSize, _dropLayer);
                if (isHit)
                {
                    Vector3Int cellPos = _tileMap.WorldToCell(transform.position);
                    Debug.Log($"{cellPos} ¸ÂÀ½");

                    _tileMap.SetTile(cellPos, currentCard.tileBase);
                    CardManager.Instance.UpdateCard();

                }
            }
        }

    }
}