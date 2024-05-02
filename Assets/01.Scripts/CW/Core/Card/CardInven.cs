using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CW
{
    public class CardInven : MonoBehaviour
    {
        public List<CardSO> _inventory = new List<CardSO>();

        /// <summary>
        /// Suffle알고리즘으로 인벤토리의 카드들을 랜덤으로 섞어줌
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
        /// _inventory에 있는 카드목록중 count개의 카드를 배열로 리턴해줌
        /// </summary>
        /// <param name="count">가져올 개수 초기값 = 10</param>
        /// <param name="suffledGet">섞은다음 가져올건지 아니면 그냥 가져올건지</param>
        /// <returns></returns>
        [ContextMenu("GetTiles")]
        public CardSO[] GetCards(int count = 10, bool suffledGet = false)
        {
            if (_inventory.Count < count)
                count = _inventory.Count - 1;

            if (suffledGet) Suffle();

            CardSO[] returnList = new CardSO[count];
            int lastIdx = _inventory.Count - 1;
            for (int i = 0; i < count; ++i)
            {
                returnList[i] = _inventory[lastIdx - i];

                _inventory.RemoveAt(lastIdx - i);
            }

            return returnList;
        } 

        /// <summary> 
        /// Count값만큰 card를 인벤토리에 추가해줌 
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