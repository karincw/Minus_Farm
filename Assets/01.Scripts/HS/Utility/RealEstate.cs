using System.Collections.Generic;
using CW;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace HS
{
    public class RealEstate : MonoBehaviour
    {
        [SerializeField] private List<Vector3Int> firstPositions = new List<Vector3Int>();
        [SerializeField] private List<Vector3Int> secondPositions = new List<Vector3Int>();
        [SerializeField] private TopBarRightUi credit;
        [SerializeField] private CardSO groundSo;
        private UtilityButton _utility;
        private ShopUi _shop;
        private Tilemap _useTileMap;
        private Tilemap _unUseTileMap;
        private bool _isUpgrade;
        private bool _isMaxUpgrade;
    
        private void Awake()
        {
            _shop = GameObject.Find("ShopPanel").GetComponent<ShopUi>();
            _utility = GameObject.Find("UtilityPanel").GetComponent<UtilityButton>();
            _useTileMap = GameObject.Find("UseTilemap").GetComponent<Tilemap>();
            _unUseTileMap = GameObject.Find("UnUseTileMap").GetComponent<Tilemap>();
        }

        public void UpgradeFarm1()
        {
            if (!_isUpgrade && credit.credit >= 10000)
            {
                foreach (var t in firstPositions)
                {
                    _useTileMap.SetTile(t, groundSo.tileBase);
                    _unUseTileMap.SetTile(t, groundSo.tileBase);
                    CropManager.Instance.AddCrop(t, groundSo);
                    _isUpgrade = true;
                    _utility.ShopClose();
                }
                credit.ChangeCredit(-10000);
            }
            else
            {
                _shop.OpenWarning();
            }
        }

        public void UpgradeFarm2()
        {
            if ((_isUpgrade && credit.credit >= 20000) && !_isMaxUpgrade)
            {
                foreach (var t in secondPositions)
                {
                    _useTileMap.SetTile(t, groundSo.tileBase);
                    _unUseTileMap.SetTile(t, groundSo.tileBase);
                    CropManager.Instance.AddCrop(t, groundSo);
                    _utility.ShopClose();
                }
                credit.ChangeCredit(-20000);
                _isMaxUpgrade = true;
            }
            else
            {
                _shop.OpenWarning();
            }
        }
    }
}