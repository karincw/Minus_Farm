using UnityEngine;
using UnityEngine.Tilemaps;

namespace CW
{
    [System.Serializable]
    public struct Crop
    {
        public int growCycle;
        public int growIdx;
        public TileBase[] cropTile;
        public Sprite sprite;

        public Crop(int growCycle, TileBase[] cropTile, Sprite sprite, int growIdx = 0)
        {
            this.growCycle = growCycle;
            this.cropTile = cropTile;
            this.growIdx = growIdx;
            this.sprite = sprite;
        }
    }

}