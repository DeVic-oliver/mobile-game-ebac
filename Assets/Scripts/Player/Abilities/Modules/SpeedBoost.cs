using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeedBoostBuff = Assets.Scripts.Items.Powerups.Buffs.SpeedBoost;

namespace Assets.Scripts.Player.Abilities.Modules
{
    public class SpeedBoost : MonoBehaviour
    {
        private PlayerMovement _playerMovement;

        // Start is called before the first frame update
        void Start()
        {
            _playerMovement = GetComponent<PlayerMovement>();
        }
       
        private void OnTriggerEnter(Collider other)
        {
            SpeedBoostBuff speedBoostItem = other.GetComponent<SpeedBoostBuff>();
            if (speedBoostItem != null)
            {
                _playerMovement.FowardMoveSpeed = speedBoostItem.GetBuffedValue(_playerMovement.FowardMoveSpeed);
                StartCoroutine(DeactiveBuff(speedBoostItem.GetBuffTimer()));
            }
        }
        private IEnumerator DeactiveBuff(float timer)
        {
            yield return new WaitForSeconds(timer);
            _playerMovement.SetOriginalFowardSpeed();
        }
    }
}