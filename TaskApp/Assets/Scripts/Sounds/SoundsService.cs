using System;
using System.Collections.Generic;
using UnityEngine;


namespace Sounds
{
    public class SoundsService : MonoBehaviour
    {
        [SerializeField] private AudioClip _shootClip;

        public AudioClip ShootClip => _shootClip;
    }
}
