using UnityEngine.Tilemaps;

namespace CW
{
    [System.Serializable]
    public struct Crop
    {
        public int growCycle;
        public int growIdx;
        public TileBase[] cropTile;

        public Crop(int growCyle, TileBase[] cropTile, int growIdx = 1)
        {
            this.growCycle = growCyle;
            this.cropTile = cropTile;
            this.growIdx = growIdx;
        }
    }

}