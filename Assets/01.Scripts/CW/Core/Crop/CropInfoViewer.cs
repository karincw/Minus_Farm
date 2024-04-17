using CW;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

namespace CW
{

    public class CropInfoViewer : MonoBehaviour
    {
        private Tilemap _tilemap;
        [SerializeField] private LayerMask targetLayer;
        [SerializeField] private TextMeshProUGUI _descriptionText;

        private void Awake()
        {
            _tilemap = GetComponent<Tilemap>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                bool isHit = Physics2D.OverlapCircle(mousePos, 0.4f, targetLayer);
                if (isHit)
                {
                    var tilePos = _tilemap.WorldToCell(mousePos);
                    CardSO card = CropManager.Instance.GetPosToCard(tilePos);
                    _descriptionText.text = card.description;
                }

            }
        }

    }

}