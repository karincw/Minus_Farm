using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace CW
{

    public enum CardType
    {
        None = 0,
        Seed,
        Item,
        Building,
    }

    public enum ItemType
    {
        Shovel = 0,
    }

    [CreateAssetMenu(menuName = "CW/SO/CardSO")]
    public class CardSO : ScriptableObject
    {
        public CardType cardType;

        [Header("Seed Settings")]
        public string curName;
        public string description;
        public Sprite sprite;
        public TileBase tileBase;

        [Header("ActionCard Settings")]
        public int action_water_changeValue;
        public int action_nutrition_changeValue;

        [Header("Item Settings")]
        public ItemType itemType;

        [Header("Building Settings")]
        public int Building_water_changeValue;
        public int Building_Nutrition_changeValue;



    }
}
