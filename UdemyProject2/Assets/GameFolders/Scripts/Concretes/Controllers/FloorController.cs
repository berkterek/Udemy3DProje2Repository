using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Controllers
{
    public class FloorController : MonoBehaviour
    {
        [Range(0.5f,2.5f)]
        [SerializeField] float _moveSpeed = 5f;
        Material _material;

        void Awake()
        {
            _material = GetComponentInChildren<MeshRenderer>().material;
        }

        void Update()
        {
            _material.mainTextureOffset += Vector2.down * Time.deltaTime * _moveSpeed;
        }
    }    
}

