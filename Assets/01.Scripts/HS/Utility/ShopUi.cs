using CW;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace HS
{
    public class ShopUi : MonoBehaviour
    {
        [SerializeField] private List<CardSO> _cardSOs = new List<CardSO>();
        [SerializeField] private List<Image> _image = new List<Image>();

        private void Awake()
        {
            SeedChange();
        }

        [ContextMenu("dsdsds")]
        public void SeedChange()
        {
            List<CardSO> _seed = _cardSOs.ToList();

            for (int i = 0; i < 6; i++)
            {
                int index = Random.Range(0, _seed.Count);
                _image[i].sprite = _seed[index].sprite;
                _seed.RemoveAt(index);
            }
        }
    }
}