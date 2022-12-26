using System.Collections;
using UnityEngine;
using Scripts.Core.Interfaces;

namespace Assets.Scripts.Player.Abilities.Modules
{
    public class CoinMagnet : MonoBehaviour
    {

        [SerializeField] private Transform _collector;
        [SerializeField] private float _magneticForce = 10f;

        private float _timerToDisable = 6f;

        
        public void ActiveAbilityBuff()
        {
            gameObject.SetActive(true);
            StartCoroutine("DisableBuff");
        }
        private IEnumerator DisableBuff()
        {
            yield return new WaitForSeconds(_timerToDisable);
            gameObject.SetActive(false);
        }

        private void OnTriggerStay(Collider other)
        {
            IScorable scorableGameObject = other.gameObject.GetComponent<IScorable>();
            if (scorableGameObject != null)
            {
                PullCoin(other.transform);
                CollectCoin(other.transform.position, scorableGameObject);
            }
        }
        private void PullCoin(Transform coinTransform)
        {
            float stepPerCall = _magneticForce * Time.deltaTime;
            coinTransform.position = Vector3.MoveTowards(coinTransform.position, _collector.localPosition, stepPerCall);

        }
        private void CollectCoin(Vector3 coinPosition, IScorable coin)
        {
            if (Vector3.Distance(_collector.position, coinPosition) <= 0f)
            {
                coin.IncreaseScore();
            }
        }
    }
}
