using System;
using UnityEngine;

namespace Mario
{
    [ExecuteInEditMode]
    public class PixelPerfectSnap : MonoBehaviour
    {
        [SerializeField] private float gridScaleX = 1;
        [SerializeField] private float gridScaleY = 1;

        private void Update()
        {
            var currentPos = transform.position;
            transform.position = new Vector3(Mathf.Round(currentPos.x / gridScaleX) * gridScaleX,
                Mathf.Round(currentPos.y / gridScaleY) * gridScaleY,
                0);
        }
    }
}