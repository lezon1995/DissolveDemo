﻿using UnityEngine;

namespace AmazingAssets.AdvancedDissolve
{
    [ExecuteAlways]
    [RequireComponent(typeof(Light))]
    public class AdvancedDissolveSpotLightToConeSmooth : MonoBehaviour
    {
        public AdvancedDissolveGeometricCutoutController geometricCutoutController;
        public AdvancedDissolveKeywords.CutoutGeometricCount countID;
        public float radiusOffset;

        private Light spotLight;

        private void Start()
        {
            spotLight = GetComponent<Light>();
        }

        private void Update()
        {
            Vector3 startPoint = transform.position;
            Vector3 endPoint = transform.position + transform.forward * spotLight.range;
            float radius = spotLight.range * Mathf.Tan((spotLight.spotAngle / 2) * Mathf.Deg2Rad);


            geometricCutoutController.SetTargetStartPointPosition(countID, startPoint);
            geometricCutoutController.SetTargetEndPointPosition(countID, endPoint);
            geometricCutoutController.SetTargetRadius(countID, radius - radiusOffset);
        }
    }
}