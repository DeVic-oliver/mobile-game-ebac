using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Items.Powerups.Abilities
{
    public class CoinMagnet : MonoBehaviour
    {

        private void Start()
        {
            gameObject.SetActive(true);
        }

        public void EnableAbility()
        {
            gameObject.SetActive(false);
        }
    }
}