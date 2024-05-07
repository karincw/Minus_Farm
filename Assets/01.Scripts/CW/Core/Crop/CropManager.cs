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

        private float plantingCooldown = 0;
        [SerializeField] private float plantingCooltime = .5f;
        public float Cooltime { get => plantingCooltime; }
        public float Cooldown { get => plantingCooldown; }
        public bool CanPlanting => plantingCooldown <= 0;

        private void Awake()
        {
            cropUtility = FindObjectOfType<CropUtility>();
        }

        private void Start()
        {
            StartCoroutine(GrowCoroutine());
            StartSetting();
        }

        private void Update()
        {
            if (plantingCooldown > 0)
            {
                plantingCooldown -= Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                NextCycle();
            }
        }


        public void ActiveCooldown()
        {
            plantingCooldown = plantingCooltime;
        }

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
                tiles[pos] = newCrop;
                return;
            }

            tiles.Add(pos, newCrop);
        }

        public void AddBuilding(Vector3Int pos, CardSO card)
        {
            Crop building = new Crop(0, null, null, card);

            if (card.cardType != CardType.Building) return;

            if (tiles.ContainsKey(pos))
            {
                tiles[pos] = building;
                return;
            }

            tiles.Add(pos, building);
        }

        public void SetGroundTile(Vector3Int tilePos)
        {
            AddCrop(tilePos, _groundSO);
            _tileMap.SetTile(tilePos, _groundSO.tileBase);
        }

        public void ChangeCrop(Vector3Int pos, Crop crop)
        {
            if (tiles.ContainsKey(pos))
            {
                tiles[pos] = crop;
                return;
            }
            Debug.LogError($"Dictionary haven't {pos}this positionKey");
        }

        public void DeleteTile(Vector3Int pos)
        {
            if (tiles.ContainsKey(pos))
            {
                tiles.Remove(pos);
                return;
            }
            Debug.LogError($"Dictionary haven't {pos}this positionKey");
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
                return new Crop();
            }
            return tiles[pos];
        }

        public void NextCycle()
        {
            nextTurn = true;
        }

        public void Harvest(Vector3Int pos, Crop crop)
        {
            if (tiles.ContainsKey(pos))
            {
                SetGroundTile(pos);
                HarvestManager.Instance.Harvest(pos, crop, 4);
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
                else //다자랐음
                {
                    if (crop.currentCard == _groundSO) continue;
                    Harvest(targetKey, crop);
                    continue;
                }
                if (tilebase != null)
                {
                    _tileMap.SetTile(targetKey, tilebase);
                }

                tiles[targetKey] = crop;
            }

            StartCoroutine(GrowCoroutine());
        }

        public Vector3Int GetRandomCropPos()
        {
            var keys = tiles.Keys.ToArray();

            int randomIndex = Random.Range(0, keys.Length);

            return keys[randomIndex];
        }
    }

}