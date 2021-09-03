using UnityEngine;
using UnityEngine.UI;

namespace LevelManagement.Utilities
{
    public class ScreenFader : MonoBehaviour
    {
        [SerializeField] protected float solidAlpha = 1f;
        [SerializeField] protected float clearAlpha = 0f;
        
        [SerializeField] private float fadeOnDuration = 1f;
        [SerializeField] private float fadeOffDuration = 1f;
        
        [SerializeField] private MaskableGraphic[] graphicsToFade;
    
        public float FadeOnDuration
        {
            get => fadeOnDuration;
            set => fadeOnDuration = value;
        }
    
        public float FadeOffDuration
        {
            get => fadeOffDuration;
            set => fadeOffDuration = value;
        }
    
        protected void SetAlpha(float alpha)
        {
            foreach (var graphic in graphicsToFade)
            {
                if (graphic != null)
                {
                    graphic.canvasRenderer.SetAlpha(alpha);
                }
            }
        }
    
        private void Fade(float targetAlpha, float duration)
        {
            foreach (var graphic in graphicsToFade)
            {
                if (graphic != null)
                {
                    graphic.CrossFadeAlpha(targetAlpha, duration, true);
                }
            }
        }
    
        public void FadeOff()
        {
            SetAlpha(solidAlpha);
            Fade(clearAlpha, fadeOffDuration);
        }
        
        public void FadeOn()
        {
            SetAlpha(clearAlpha);
            Fade(solidAlpha, fadeOnDuration);
        }
    }
}

