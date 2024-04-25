using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace CW
{
    public class DragAndDrop : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _detectRadius;
        [SerializeField] private LayerMask _dropToPlantLayer;
        [SerializeField] private LayerMask _dropToSellLayer;
        [SerializeField] private Tilemap _tileMap;
        [SerializeField] private TileBase _canPlantingTile;
        CardSO currentCard;

        private void Start()
        {

        }

        private void Update()
        {
            var DMInstance = DragAndDropManager.Instance;
            currentCard = DMInstance.Card;
            if (DMInstance.CanDrop && Input.GetMouseButtonUp(0))
            {
                switch(DMInstance.currentType)
                {
                    case CardType.None:
                        DropToSelling();
                        break;

                    case CardType.Seed:
                        DropToPlanting();
                        break;

                    case CardType.Item:
                        DropToAction();
                        break;

                    case CardType.Building:
                        break;
                }

            }
        }

        private void DropToAction()
        {
            DragAndDropManager.Instance.SetImage();

            bool isHit = Physics2D.OverlapCircle(transform.position, _detectRadius, _dropToPlantLayer);
            if (isHit)
            {
                Vector3Int tilePos = _tileMap.WorldToCell(transform.position);

                bool isNull = true;
                Crop crop = CropManager.Instance.GetPosToCrop(tilePos, ref isNull);
                if (!isNull)
                {
                    crop.water += DragAndDropManager.Instance.Card.action_water_changeValue;
                    crop.nutrition += DragAndDropManager.Instance.Card.action_nutrition_changeValue;
                    CropManager.Instance.ChangeCrop(tilePos, crop);
                }

            }

            CardManager.Instance.UpdateCard();
        }

        private void DropToPlanting()
        {
            DragAndDropManager.Instance.SetImage();
            bool isHit = Physics2D.OverlapCircle(transform.position, _detectRadius, _dropToPlantLayer);
            if (isHit)
            {
                Vector3Int cellPos = _tileMap.WorldToCell(transform.position);
                if (_tileMap.GetTile(cellPos) != _canPlantingTile) return;

                _tileMap.SetTile(cellPos, currentCard.tileBase);
                CropManager.Instance.AddCrop(cellPos, currentCard);
                CardManager.Instance.UpdateCard();

            }
        }

        private void DropToSelling()
        {
            DragAndDropManager.Instance.SetImage();
            bool isHit = Physics2D.OverlapCircle(transform.position, _detectRadius, _dropToSellLayer);
            if (isHit)
            {
                //판매 이미지 띄우기
            }
        }
    }
}