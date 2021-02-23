using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Managers;
using UdemyProject2.Movements;
using UnityEngine;

namespace UdemyProject2.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] float _moveSpeed = 10f;
        [SerializeField] float _maxLifeTime = 10f;
        
        VerticalMover _mover;
        float _currentLifeTime = 0f;

        public float MoveSpeed => _moveSpeed;

        void Awake()
        {
            _mover = new VerticalMover(this);
        }

        void Update()
        {
            _currentLifeTime += Time.deltaTime;

            if (_currentLifeTime > _maxLifeTime)
            {
                _currentLifeTime = 0f;
                KillYourself();
            }
        }

        void FixedUpdate()
        {
            _mover.FixedTick();
        }
        
        void KillYourself()
        {
            EnemyManager.Instance.SetPool(this);
        }
    }    
}

