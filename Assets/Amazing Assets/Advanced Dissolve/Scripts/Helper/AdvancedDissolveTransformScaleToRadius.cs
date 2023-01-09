using UnityEngine;

namespace AmazingAssets.AdvancedDissolve
{
    [ExecuteAlways]
    public class AdvancedDissolveTransformScaleToRadius : MonoBehaviour
    {
        public AdvancedDissolveGeometricCutoutController geometricCutoutController;
        public AdvancedDissolveKeywords.CutoutGeometricCount countID;

        private void Update()
        {
            if (geometricCutoutController == null)
                return;

            float radius = transform.lossyScale.x * .5f;

            geometricCutoutController.SetTargetStartPointTransform(countID, transform);
            geometricCutoutController.SetTargetRadius(countID, radius);
        }
    }
}