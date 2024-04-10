using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace CW
{
    public class CropManager : MonoSingleton<CropManager>
    {
        [Header("Settings")]
        [SerializeField] private Tilemap _tileMap;
        [SerializeField] private Vector2 _offsetCenterPos;

        [SerializeField] private Dictionary<Vector2, TileBase> tiles = new Dictionary<Vector2, TileBase>();

        private void Start()
        {
        }

        public void TileFindAll()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {

                }
            }
        }

    }

}