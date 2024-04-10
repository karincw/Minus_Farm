using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace CW
{
    public class CropManager : MonoSingleton<CropManager>
    {
        [Header("Settings")]
        [SerializeField] private Tilemap _tileMap;
        [SerializeField] private Vector3Int _offsetCenterPos;
         private CropUtility _cropUtility;

        [SerializeField] private SerializedDictionary<Vector3Int, Crop> tiles = new SerializedDictionary<Vector3Int, Crop>();

        private void Awake()
        {
            _cropUtility = FindObjectOfType<CropUtility>();
        }

        public void AddCrop(Vector3Int pos, CardSO card)
        {
            Crop newCropData = _cropUtility.cardToCropDataDic[card];
            Crop newCrop = new Crop(newCropData.growCycle, newCropData.cropTile);
            tiles.Add(pos, newCrop);
            foreach (var item in tiles)
            {
                Crop crop = item.Value;
                crop.growIdx++;
            }
        } 

        public CardSO card;
        [ContextMenu("Test")]
        public void AllTest()
        {
            AddCrop(new Vector3Int(0, 0, 0), card);

            StartCoroutine(Test());
        }

        public IEnumerator Test()
        {
            yield return new WaitForSeconds(2);
            foreach (var item in tiles)
            {
                Crop crop = tiles[item.Key];
                crop.growIdx++;
                tiles[item.Key] = crop;
                //내용 변경되서 에러남                
            }
        }

    }

}