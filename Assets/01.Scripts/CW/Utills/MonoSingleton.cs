using UnityEngine;

namespace CW
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        private static T Instance
        {
            get
            {
                if (Instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        Debug.LogError($"{typeof(T).ToString()} Singleton ins not have in 하이라키");
                    }
                }

                return instance;
            }
        }
    }
}