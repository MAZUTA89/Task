using BonusLogic;
using PlayerCode;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BonusesLojic
{
    public abstract class BonusTrigger : MonoBehaviour
    {
        protected Player Player;
        public virtual void Initialize(Player player)
        {
            Player = player;
        }
        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Player.PlayerTag))
            {
                OnPlayerTriggered();

                Destroy(gameObject);
            }
        }

        protected virtual void OnPlayerTriggered()
        {

        }
    }
}
