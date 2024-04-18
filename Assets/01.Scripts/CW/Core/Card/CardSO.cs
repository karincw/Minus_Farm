using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace CW
{
    [CreateAssetMenu(menuName = "CW/SO/CardSO")]
    public class CardSO : ScriptableObject
    {
        public string curName;
        public string description;
        public Sprite sprite;
        public TileBase tileBase;
        public int price;
    }
}
