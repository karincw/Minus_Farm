using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CW
{
    [CreateAssetMenu(menuName = "CW/SO/CardSO")]
    public class CardSO : ScriptableObject
    {
        public string curName;
        public int age;
    }
}
