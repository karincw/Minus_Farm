using UnityEngine;
using UnityEngine.Tilemaps;
using HS;

namespace CW
{
    public class DragAndDrop : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _detectRadius;
        [SerializeField] private LayerMask _dropToPlantLayer;
        [SerializeField] private LayerMask _dropToSellLayer;
        [SerializeField] private Tilemap _tileMap;
        UiButton _uiButton;
        CardSO currentCard;
        public int cropCount, cropPrice;

        private void Awake()
        {
            _uiButton = GameObject.Find("UtilityPanel").GetComponent<UiButton>();
        }

        private void Update()
        {
            currentCard = DragAndDropManager.Instance.Card;
            if (DragAndDropManager.Instance.CanDrop && Input.GetMouseButtonUp(0))
            {
                if (DragAndDropManager.Instance.IsSeed == true)
                {
                    DropToPlanting();
                }
                else
                {
                    DropToSelling(cropCount, cropPrice);
                }
            }
        }

        private void DropToPlanting()
        {
            DragAndDropManager.Instance.SetImage();
            bool isHit = Physics2D.OverlapCircle(transform.position, _detectRadius, _dropToPlantLayer);
            if (isHit)
            {
                Vector3Int cellPos = _tileMap.WorldToCell(transform.position);
                Debug.Log($"{cellPos} ¸ÂÀ½");

                _tileMap.SetTile(cellPos, currentCard.tileBase);
                CropManager.Instance.AddCrop(cellPos, currentCard);
                CardManager.Instance.UpdateCard();

            }
        }

        private void DropToSelling(int cropCount, int cropPrice)
        {
            bool isHit = Physics2D.OverlapCircle(transform.position, _detectRadius, _dropToSellLayer);
            if (isHit)
            {
                Debug.Log($"DropToSelling");

                _uiButton.SellOpen(cropCount, cropPrice);
            }
            DragAndDropManager.Instance.SetImage();
        }
    }
}