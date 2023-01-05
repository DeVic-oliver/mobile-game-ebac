using UnityEngine;
using Scripts.Core.Interfaces;
using System.Collections;

public class Coin : MonoBehaviour, IScorable
{
    public static int CoinsCollected = 0;

    [SerializeField] private float _rotationSpeed;
    private bool _isCollected;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")){
            IncreaseScore();
        }
    }
    public void IncreaseScore()
    {
        CoinsCollected++;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        RotateCoinIfNotCollected();
    }
    private void RotateCoinIfNotCollected()
    {
        if (!_isCollected)
        {
            Vector3 eulers = Vector3.up * _rotationSpeed * Time.deltaTime;
            transform.Rotate(eulers);
        }
    }

}
