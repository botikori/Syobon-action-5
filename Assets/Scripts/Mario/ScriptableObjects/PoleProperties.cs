using UnityEngine;

namespace Mario.ScriptableObjects
{
    [CreateAssetMenu(fileName = "PoleAsset", menuName = "ScriptableObjects/PoleAsset")]
    public class PoleProperties : ScriptableObject
    {
        public GameObject poleTop;
        public GameObject poleBottom;
        public bool hasTop;
    }
}