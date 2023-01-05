using System.Collections;
using UnityEngine;
using CoinMagnetPowerUp = Assets.Scripts.Items.Powerups.Abilities.CoinMagnet;
using CoinMagnetModule = Assets.Scripts.Player.Abilities.Modules.CoinMagnet;
using Assets.Scripts.Utils.Dotween;

namespace Assets.Scripts.Player.Abilities
{
    public class CoinMagnet : MonoBehaviour
    {
        [SerializeField] private CoinMagnetModule coinMagnetGameObject;

        private void OnTriggerEnter(Collider other)
        {
            CoinMagnetPowerUp powerUp = other.gameObject.GetComponent<CoinMagnetPowerUp>();
            if (powerUp != null)
            {
                DotweenHelper.ScaleYoYo(gameObject);
                powerUp.gameObject.SetActive(false);
                coinMagnetGameObject.ActiveAbilityBuff();
            }
        }
    }
}