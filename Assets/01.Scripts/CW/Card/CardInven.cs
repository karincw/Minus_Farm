using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CW
{
    public class CardInven : MonoBehaviour
    {
        [SerializeField] private List<CardSO> _inventory = new List<CardSO>();

        /// <summary>
        /// Suffle�˰������� �κ��丮�� ī����� �������� ������
        /// </summary>
        /// <param name="suffleCount"></param>
        [ContextMenu("Suffle")]
        public void Suffle(int suffleCount = 100)
        {
            for (int i = 0; i < suffleCount; ++i)
            {
                int first = Random.Range(0, _inventory.Count);
                int second = Random.Range(0, _inventory.Count);

                var temp = _inventory[first];
                _inventory[first] = _inventory[second];
                _inventory[second] = temp;
            }
        }

        /// <summary>
        /// _inventory�� �ִ� ī������ count���� ī�带 �迭�� ��������
        /// </summary>
        /// <param name="count">������ ���� �ʱⰪ = 10</param>
        /// <param name="suffledGet">�������� �����ð��� �ƴϸ� �׳� �����ð���</param>
        /// <returns></returns>
        [ContextMenu("GetTiles")]
        public CardSO[] GetCards(int count = 10, bool suffledGet = false)
        {
            if (_inventory.Count < count)
                count = _inventory.Count - 1;

            if (suffledGet) Suffle();

            CardSO[] returnList = new CardSO[count];
            for (int i = 0; i < count; ++i)
            {
                returnList[i] = _inventory[count - i];

                _inventory.RemoveAt(count - i);
            }

            return returnList;
        }

        /// <summary>
        /// Count����ū card�� �κ��丮�� �߰����� 
        /// </summary>
        /// <param name="card"></param>
        /// <param name="count"></param>
        public void AddCard(CardSO card, int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                _inventory.Add(card);
            }
        }

    }
}