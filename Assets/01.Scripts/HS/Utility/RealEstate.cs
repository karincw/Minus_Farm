using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace HS
{
    public class RealEstate : MonoBehaviour
    {
        [SerializeField] private TileBase tile;
        [SerializeField] private List<Vector3Int> firstPositions = new List<Vector3Int>();
        [SerializeField] private List<Vector3Int> secondPositions = new List<Vector3Int>();
        [SerializeField] private TopBarRightUi credit;
        private UtilityButton _utility;
        private Tilemap _tilemap;
        private bool _isUpgrade;    
    
        private void Awake()
        {
            // CropManager.Instance.
            _utility = GameObject.Find("UtilityPanel").GetComponent<UtilityButton>();
            _tilemap = GameObject.Find("UseTilemap").GetComponent<Tilemap>();
        }

        public void UpgradeFarm1()
        {
            if (credit.credit >= 10000)
            {
                foreach (var t in firstPositions)
                {
                    _tilemap.SetTile(t, tile);
                    _isUpgrade = true;
                    _utility.ShopClose();
                }
                credit.ChangeCredit(-10000);
            }
        }

        public void UpgradeFarm2()
        {
            if (_isUpgrade && credit.credit >= 20000)
            {
                foreach (var t in secondPositions)
                {
                    _tilemap.SetTile(t, tile);
                    _utility.ShopClose();
                }
                credit.ChangeCredit(-20000);
            }
        }
    }
}