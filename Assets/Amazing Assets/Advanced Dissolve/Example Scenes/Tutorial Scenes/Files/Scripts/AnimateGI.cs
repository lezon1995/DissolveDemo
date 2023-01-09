using UnityEngine;

namespace AmazingAssets.AdvancedDissolve.ExampleScripts
{
    public class AnimateGI : MonoBehaviour
    {
        Renderer mRenderer;

        private void Start()
        {
            mRenderer = GetComponent<Renderer>();
        }

        private void Update()
        {
            //We need to update Unity GI every time we change material properties effecting GI
            mRenderer.UpdateGIMaterials();
        }
    }
}