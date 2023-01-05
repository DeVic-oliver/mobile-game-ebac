using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Items.Powerups.Abilities
{
    public class CoinMagnet : MonoBehaviour
    {

        [SerializeField] private ParticleSystem _particleSystem;

        private void Start()
        {
            gameObject.SetActive(true);
            GetComponent<Collider>().enabled = true;
            GetComponent<MeshRenderer>().enabled = true;
        }

        public void EnableAbility()
        {
            StartCoroutine(DisableMe());
        }

        private IEnumerator DisableMe()
        {
            _particleSystem.Play();
            GetComponent<Collider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(2f);
            gameObject.SetActive(false);
        }
    }
}