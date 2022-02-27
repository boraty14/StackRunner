using Core;
using SO;
using UnityEngine;

namespace User
{
    public class UserParticle : MonoBehaviour
    {
        [SerializeField] private SUser userSettings;

        private UserStack _userStack;

        private ParticleSystem _trailParticle;
        private ParticleSystem _winParticle;

        private void OnEnable()
        {
            _userStack = GetComponent<UserStack>();
            EventBus.OnLevelReset += OnLevelReset;
            EventBus.OnTapToPlay += OnTapToPlay;
            EventBus.OnLevelWin += OnLevelWin;
            _userStack.OnHitObstacle += OnHitObstacle;
        }

        private void OnDisable()
        {
            EventBus.OnLevelReset -= OnLevelReset;
            EventBus.OnTapToPlay -= OnTapToPlay;
            EventBus.OnLevelWin -= OnLevelWin;
            _userStack.OnHitObstacle -= OnHitObstacle;
        }

        private void OnLevelReset()
        {
            if(_winParticle) Destroy(_winParticle.gameObject);
        }
        
        private void OnTapToPlay()
        {
            _trailParticle = Instantiate(userSettings.TrailParticle,transform);
        }

        private void OnHitObstacle()
        {
            Instantiate(userSettings.HitParticle, transform);
        }

        private void OnLevelWin()
        {
            Destroy(_trailParticle.gameObject);
            _winParticle = Instantiate(userSettings.WinParticle, transform);
        }

    }
}
