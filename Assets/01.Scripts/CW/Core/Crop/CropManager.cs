using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace CW
{
    public class CropManager : MonoSingleton<CropManager>
    {
        [Header("Settings")]
        [SerializeField] private Tilemap _tileMap;
        public bool nextTurn;

        [SerializeField] private SerializedDictionary<Vector3Int, Crop> tiles = new SerializedDictionary<Vector3Int, Crop>();
        [HideInInspector] public CropUtility cropUtility;

        private void Awake()
        {
            cropUtility = FindObjectOfType<CropUtility>();
        }

        private void Start()
        {
            StartCoroutine(GrowCoroutine());
        }

        public void AddCrop(Vector3Int pos, CardSO card)
        {
            Crop newCropData = cropUtility.cardToCropDataDic[card];
            Crop newCrop = new Crop(newCropData.growCycle, newCropData.cropTile, newCropData.sprite);

            if (tiles.ContainsKey(pos))
            {
                Debug.LogError($"Dictionary DoubleAdd : {pos}this positionKey is contain");
                return;
            }

            tiles.Add(pos, newCrop);
        }

        public IEnumerator GrowCoroutine()
        {
            yield return new WaitUntil(() =>
            {
                if (nextTurn == true)
                {
                    nextTurn = false;
                    return true;
                }
                return false;
            });

            for (int i = 0; i < tiles.Count; i++)
            {
                var targetKey = tiles.Keys.ToList()[i];
                Crop crop = tiles[targetKey];
                crop.growIdx++;

                //�Ĺ��� �ڶ����� Ȯ��
                TileBase tilebase = null;
                int cropGrowIdx = crop.growIdx / crop.growCycle;

                if (crop.cropTile.Length - 1 >= cropGrowIdx)
                {
                    tilebase = crop.cropTile[cropGrowIdx];
                }
                else
                {
                    Debug.Log("����?");
                }

                if (tilebase != null)
                {
                    _tileMap.SetTile(targetKey, tilebase);
                }

                tiles[targetKey] = crop;
            }

            StartCoroutine(GrowCoroutine());
        }

    }

}