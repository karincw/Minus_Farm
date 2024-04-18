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
        [SerializeField] private CardSO _groundSO;
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
            StartSetting();
        }

#if UNITY_EDITOR

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                nextTurn = true;
            }
        }

#endif


        private void StartSetting()
        {
            for (int i = -2; i < 1; i++)
            {
                for (int j = -2; j < 1; j++)
                {
                    Vector3Int cellPos = _tileMap.WorldToCell(new Vector3Int(i, j));

                    _tileMap.SetTile(cellPos, _groundSO.tileBase);
                    CropManager.Instance.AddCrop(cellPos, _groundSO);
                }
            }
        }

        public void AddCrop(Vector3Int pos, CardSO card)
        {
            Crop newCropData = cropUtility.cardToCropDataDic[card];
            Crop newCrop = new Crop(newCropData.growCycle, newCropData.cropTile, newCropData.sprite, card);

            if (tiles.ContainsKey(pos))
            {
                //Debug.LogError($"Dictionary DoubleAdd : {pos}this positionKey is contain");
                tiles[pos] = newCrop;
                return;
            }

            tiles.Add(pos, newCrop);
        }
        public Crop GetPosToCrop(Vector3Int pos, ref bool IsNull)
        {
            if (tiles.ContainsKey(pos))
            {
                IsNull = false;
            }
            else
            {
                IsNull = true;
                Debug.LogError($"tiles is Not Have {pos}");
            }
            return tiles[pos];
        }

        public void NextCycle()
        {
            nextTurn = true;
        }

        public void Harvest(Vector3Int pos)
        {
            if (tiles.ContainsKey(pos))
            {
                _tileMap.SetTile(pos, _groundSO.tileBase);
                //수확 사잍클
            }
            else
            {
                Debug.LogError($"tiles is Not Have {pos}");
            }
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
                crop.water -= 10;
                crop.nutrition -= 10;

                //식물이 자랐는지 확인
                TileBase tilebase = null;
                int cropGrowIdx = crop.growIdx / crop.growCycle;

                if (crop.cropTile.Length - 1 >= cropGrowIdx)
                {
                    tilebase = crop.cropTile[cropGrowIdx];
                }
                else
                {

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