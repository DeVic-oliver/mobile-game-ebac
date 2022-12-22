using System.Collections;
using UnityEngine;
using Scripts.Core.Interfaces;
using Assets.Scripts.SceneManager;

namespace Assets.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        public static bool isAlive { get; private set; }

        private string _obstacleTag = "Obstacle";
        private string _finishLineTag = "FinishLine";

        private void Awake()
        {
            isAlive = true;
        }

        // Use this for initialization
        void Start()
        {
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
                isAlive = false;
            }

            if (collision.gameObject.CompareTag(_finishLineTag))
            {
                GameManager.IsPlayerReachedFinishlLine = true;
            }
        }

    }
}