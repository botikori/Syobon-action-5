using UnityEngine;

namespace LevelManagement.Utilities
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private void Awake()
        {
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
        }
    }
}
