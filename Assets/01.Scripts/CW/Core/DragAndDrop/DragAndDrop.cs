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
        CardSO currentCard;

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
                    DropToSelling();
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
                Debug.Log($"{cellPos} 맞음");

                _tileMap.SetTile(cellPos, currentCard.tileBase);
                CropManager.Instance.AddCrop(cellPos, currentCard);
                CardManager.Instance.UpdateCard();

            }
        }

        private void DropToSelling()
        {
            DragAndDropManager.Instance.SetImage();
            Debug.Log($"DropToSelling");
            bool isHit = Physics2D.OverlapCircle(transform.position, _detectRadius, _dropToSellLayer);
            if (isHit)
            {
                //판매 이미지 띄우기
            }
        }
    }
}