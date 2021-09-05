using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mario
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform cameraTarget;
        [SerializeField] private float smoothSpeed = 0.125f;
        [SerializeField] private bool lockY = true;

        private Vector3 velocity = Vector3.zero;
        
        private void LateUpdate()
        {
            if (lockY)
            {
                var playerPos = new Vector3(cameraTarget.position.x, transform.position.y, transform.position.z);
                transform.position = new Vector3(cameraTarget.position.x, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(cameraTarget.position.x, cameraTarget.position.y, transform.position.z);
            }
            
        }
    }
}