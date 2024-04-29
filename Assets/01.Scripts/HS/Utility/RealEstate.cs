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
        private Tilemap _tilemap;
        private bool _isUpgrade;    
    
        private void Awake()
        {
            _shop = GameObject.Find("ShopPanel").GetComponent<ShopUi>();
            _utility = GameObject.Find("UtilityPanel").GetComponent<UtilityButton>();
            _tilemap = GameObject.Find("UseTilemap").GetComponent<Tilemap>();
        }

        public void UpgradeFarm1()
        {
            if (!_isUpgrade && credit.credit >= 10000)
            {
                foreach (var t in firstPositions)
                {
                    _tilemap.SetTile(t, groundSo.tileBase);
                    CropManager.Instance.AddCrop(t, groundSo);
                    _isUpgrade = true;
                    _utility.ShopClose();
                }
                credit.ChangeCredit(-10000);
            }
            else if (!_isUpgrade)
            {
                _shop.OpenWarning();
            }
        }

        public void UpgradeFarm2()
        {
            if (_isUpgrade && credit.credit >= 20000)
            {
                foreach (var t in secondPositions)
                {
                    _tilemap.SetTile(t, groundSo.tileBase);
                    CropManager.Instance.AddCrop(t, groundSo);
                    _utility.ShopClose();
                }
                credit.ChangeCredit(-20000);
            }
            else
            {
                _shop.OpenWarning();
            }
        }
    }
}