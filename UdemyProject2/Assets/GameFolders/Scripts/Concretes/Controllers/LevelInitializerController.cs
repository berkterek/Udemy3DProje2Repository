using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Managers;
using UdemyProject2.ScriptableObjects;
using UnityEngine;

namespace UdemyProject2.Controllers
{
    public class LevelInitializerController : MonoBehaviour
    {
        LevelDifficultyData _levelDifficultyData;

        void Awake()
        {
            _levelDifficultyData = GameManager.Instance.LevelDifficultyData;
        }

        void Start()
        {
            RenderSettings.skybox = _levelDifficultyData.SkyboxMaterial;
            Instantiate(_levelDifficultyData.FloorPrefab);
            Instantiate(_levelDifficultyData.SpanwerPrefab);
            EnemyManager.Instance.SetMoveSpeed(_levelDifficultyData.MoveSpeed);
            EnemyManager.Instance.SetAddDelayTime(_levelDifficultyData.AddDelayTime);
        }
    }    
}

