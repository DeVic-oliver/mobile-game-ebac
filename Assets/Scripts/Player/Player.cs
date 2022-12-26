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


        private void OnCollisionEnter(Collision collision)
        {
            CheckObstacleCollision(collision);

            CheckFinishLineCollision(collision);

            CheckCoinCollision(collision);

        }
        private void CheckObstacleCollision(Collision collision)
        {
            if (collision.gameObject.CompareTag(_obstacleTag))
            {
                isAlive = false;
            }
        }
        private void CheckFinishLineCollision(Collision collision)
        {
            if (collision.gameObject.CompareTag(_finishLineTag))
            {
                GameManager.IsPlayerReachedFinishlLine = true;
            }
        }
        private void CheckCoinCollision(Collision collision)
        {
            IScorable scorableGameObject = collision.gameObject.GetComponent<IScorable>();
            if (scorableGameObject != null)
            {
                scorableGameObject.IncreaseScore();
            }
        }
    

    }
}