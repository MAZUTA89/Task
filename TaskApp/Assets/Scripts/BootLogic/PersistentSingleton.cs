﻿using UnityEngine;

namespace BootLogic
{
    public class PersistentSingleton<T> : Singleton<T>
        where T : MonoBehaviour
    {
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
    }
}
