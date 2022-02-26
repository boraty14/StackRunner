using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI
{
    public class UIHandler : MonoBehaviourSingleton<UIHandler>
    {
        [SerializeField] private Image fadeImage;
        
        public YieldInstruction WaitForFade(float targetFade,float fadeDuration,Ease fadeEase = Ease.InSine)
        {
            fadeImage.raycastTarget = true;
            return fadeImage.DOFade(targetFade, fadeDuration).SetEase(fadeEase).OnComplete(() =>
            {
                fadeImage.raycastTarget = false;
            }).WaitForCompletion();
        }
    }
}
