using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Abstracts.Utilities;
using UdemyProject2.Controllers;
using UdemyProject2.Enums;
using UnityEngine;

namespace UdemyProject2.Managers
{
    public class EnemyManager : SingletonMonoBehaviorObject<EnemyManager>
    {
        [SerializeField] float _addDelayTime = 50f;
        [SerializeField] EnemyController[] _enemyPrefabs;

        Dictionary<EnemyEnum, Queue<EnemyController>> _enemies = new Dictionary<EnemyEnum, Queue<EnemyController>>();

        public float AddDelayTime => _addDelayTime;
        public int Count => _enemyPrefabs.Length;

        void Awake()
        {
            SingletonThisObject(this);
        }

        void Start()
        {
            InitializePool();
        }

        void InitializePool()
        {
            for (int i = 0; i < _enemyPrefabs.Length; i++)
            {
                Queue<EnemyController> enemyControllers = new Queue<EnemyController>();
                
                for (int j = 0; j < 10; j++)
                {
                    EnemyController newEnemy = Instantiate(_enemyPrefabs[i]);
                    newEnemy.gameObject.SetActive(false);
                    newEnemy.transform.parent = this.transform;
                    enemyControllers.Enqueue(newEnemy);
                }    
                
                _enemies.Add((EnemyEnum)i,enemyControllers);
            }
        }

        public void SetPool(EnemyController enemyController)
        {
            enemyController.gameObject.SetActive(false);
            enemyController.transform.parent = this.transform;

            Queue<EnemyController> enemyControllers = _enemies[enemyController.EnemyType];
            enemyControllers.Enqueue(enemyController);
        }

        public EnemyController GetPool(EnemyEnum enemyType)
        {
            Queue<EnemyController> enemyControllers = _enemies[enemyType];

            if (enemyControllers.Count == 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    EnemyController newEnemy = Instantiate(_enemyPrefabs[(int) enemyType]);
                    enemyControllers.Enqueue(newEnemy);    
                }
            }

            return enemyControllers.Dequeue();
        }
    }
}