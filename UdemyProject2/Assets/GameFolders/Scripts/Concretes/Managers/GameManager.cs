using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Abstracts.Utilities;
using UnityEngine;

namespace UdemyProject2.Managers
{
    public class GameManager : SingletonMonoBehaviorObject<GameManager>
    {
        void Awake()
        {
            SingletonThisObject(this);
        }

        public void StopGame()
        {
            Time.timeScale = 0f;
        }

        public void LoadScene()
        {
            Debug.Log("Load Scene clicked");
            //load islemleri
        }

        public void ExitGame()
        {
            Debug.Log("Exit on clicked");
            Application.Quit();
        }
    }    
}

