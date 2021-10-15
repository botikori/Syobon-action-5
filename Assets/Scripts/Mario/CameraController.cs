using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mario
{
    public class CameraController : MonoBehaviour
    {
        [Header("Camera target")]
        [SerializeField] private Transform cameraTarget;

        [Header("Camera smoothing")]
        [SerializeField] private float smoothSpeed = 0.3f;
        
        [Header("Min, max camera position")]
        [SerializeField] private float minXPosition = 0.0f;
        [SerializeField] private float maxXPosition = 100.0f;

        private Vector3 _velocity;

        private void Update()
        {
            if (cameraTarget.position.x > minXPosition && cameraTarget.position.x < maxXPosition)
            {
                transform.position = new Vector3(cameraTarget.transform.position.x, transform.position.y,
                    transform.position.z);
            }
        }
    }
}