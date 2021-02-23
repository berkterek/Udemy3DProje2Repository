using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Abstracts.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UdemyProject2.Managers
{
    public class GameManager : SingletonMonoBehaviorObject<GameManager>
    {
        public event System.Action OnGameStop;
        
        void Awake()
        {
            SingletonThisObject(this);
        }

        public void StopGame()
        {
            Time.timeScale = 0f;

            // if (OnGameStop != null)
            // {
            //     OnGameStop();
            // }
            
            OnGameStop?.Invoke();
        }

        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            Time.timeScale = 1f;
            yield return SceneManager.LoadSceneAsync(sceneName);
        }

        public void ExitGame()
        {
            Debug.Log("Exit on clicked");
            Application.Quit();
        }
    }    
}

