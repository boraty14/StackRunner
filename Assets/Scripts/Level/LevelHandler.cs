using System.Collections;
using System.Collections.Generic;
using Core;
using DG.Tweening;
using SO;
using UnityEngine;
using Utils;

namespace Level
{
    public class LevelHandler : MonoBehaviourSingleton<LevelHandler>
    {
        [SerializeField] private SLevels levels;
        
        private List<SLevel> _randomLevels = new List<SLevel>();
        private GameObject _currentLevelInstance;
        
        private void Start()
        {
            GenerateLevels();
            ResetLevel();
        }

        private void GenerateLevels()
        {
            _randomLevels = new List<SLevel>(levels.Levels);
            
            int currentLevelIndex = SaveHandler.LoadLevel();
            if (currentLevelIndex >= _randomLevels.Count)
            {
                _randomLevels.ShuffleList();
            }
        }

        public void GoNextLevel()
        {
            int currentLevelIndex = SaveHandler.LoadLevel();
            SaveHandler.SaveLevel(currentLevelIndex+1);
            if (currentLevelIndex + 1 % _randomLevels.Count == 0)
            {
                _randomLevels.ShuffleList();
            }
            ResetLevel();

        }

        private void ResetLevel()
        {
            if (_currentLevelInstance != null)
            {
                Destroy(_currentLevelInstance);
            }
            
            int currentLevelIndex = SaveHandler.LoadLevel();
            _currentLevelInstance = Instantiate(levels.Levels[currentLevelIndex % _randomLevels.Count].LevelPrefab);
            EventBus.OnLevelReset?.Invoke();
        }
    }
}
