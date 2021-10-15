using System;
using UnityEngine;

namespace Mario.Tiles
{
    public class RotatingBlock : MonoBehaviour
    {
        [Header("Degree settings")] 
        [SerializeField] private float degreesPerSecond = 20;

        private void Update()
        {
            transform.RotateAround(transform.position, Vector3.forward, degreesPerSecond * Time.deltaTime);
        }
    }
}