using System;
using System.Collections;
using Core;
using DG.Tweening;
using Level;
using SO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI
{
    public class UIHandler : MonoBehaviourSingleton<UIHandler>
    {
        [SerializeField] private SFade fadeSettings;
        
        //images
        private Image _fadeImage;
        
        //panels
        private GameObject _fadePanel;
        private GameObject _tapToPlayPanel;
        private GameObject _gamePlayPanel;
        private GameObject _levelEndPanel;
        
        private void Awake()
        {
            GetPanels();
        }

        private void OnEnable()
        {
            EventBus.OnLevelReset += OnLevelReset;
            EventBus.OnTapToPlay += OnTapToPlay;
            EventBus.OnLevelWin += OnLevelWin;
        }

        private void OnDisable()
        {
            EventBus.OnLevelReset -= OnLevelReset;
            EventBus.OnTapToPlay -= OnTapToPlay;
            EventBus.OnLevelWin -= OnLevelWin;
        }

        private void OnLevelReset()
        {
            
        }

        private void OnTapToPlay()
        {
        }

        private void OnLevelWin()
        {
        }

        private YieldInstruction WaitForFade(float targetFade,float fadeDuration,Ease fadeEase = Ease.InSine)
        {
            _fadeImage.raycastTarget = true;
            return _fadeImage.DOFade(targetFade, fadeDuration).SetEase(fadeEase).OnComplete(() =>
            {
                _fadeImage.raycastTarget = false;
            }).WaitForCompletion();
        }

        public void PressTapToPlay()
        {
            EventBus.OnTapToPlay?.Invoke();
        }

        public void PressNextLevel()
        {
            StartCoroutine(PressNextLevelRoutine());
            
        }

        private IEnumerator PressNextLevelRoutine()
        {
            _levelEndPanel.SetActive(false);
            yield return WaitForFade(1f, fadeSettings.FadeDuration, fadeSettings.FadeEase);
            LevelHandler.Instance.GoNextLevel();
            yield return WaitForFade(0f, fadeSettings.FadeDuration, fadeSettings.FadeEase);
            _tapToPlayPanel.SetActive(true);
        }

        private void GetPanels()
        {
            // Side Note: I am well aware that you can set these objects
            // by using serialize field attribute but I would like to use editor as minimum
            // as possible and set dependencies from code. Just a personal preference.
            _fadePanel = transform.Find("FadePanel").gameObject;
            _fadeImage = _fadePanel.GetComponentInChildren<Image>(true);
            _tapToPlayPanel = transform.Find("TapToPlayPanel").gameObject;
            _gamePlayPanel = transform.Find("GamePlayPanel").gameObject;
            _levelEndPanel = transform.Find("LevelEndPanel").gameObject;
        }
    }
}
