using System.Collections;
using UnityEngine;
using Scripts.Core.Interfaces;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(PlayerMovement))]
    public class Player : MonoBehaviour
    {
        private string _obstacleTag = "Obstacle";
        private PlayerMovement _playerMovement;

        // Use this for initialization
        void Start()
        {
            InitComponents();
            InitPlayerStatusToMovement();
        }
        private void InitComponents()
        {
            _playerMovement = GetComponent<PlayerMovement>();
        }
        private void InitPlayerStatusToMovement()
        {
            _playerMovement.isAlive = true;
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider collision)
        {
            IScorable scorableGameObject = collision.gameObject.GetComponent<IScorable>();
            if (scorableGameObject != null)
            {
                scorableGameObject.IncreaseScore();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(_obstacleTag))
            {
                _playerMovement.isAlive = false;
            }
        }

    }
}