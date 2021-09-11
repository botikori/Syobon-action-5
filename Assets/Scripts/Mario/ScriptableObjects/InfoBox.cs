using UnityEngine;

namespace Mario.ScriptableObjects
{
    [CreateAssetMenu(fileName = "InfoBox", menuName = "ScriptableObjects/InfoBox")]
    public class InfoBox : ScriptableObject
    {
        public string title;
        public string text;
    }
}