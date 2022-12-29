using UnityEngine;
using Scripts.Core.Interfaces;
using System.Collections;

public class Coin : MonoBehaviour, IScorable
{
    public static int CoinsCollected = 0;

    [SerializeField] private float _rotationSpeed;
    private bool _isCollected;
    private float _timerToDisable = 0.3f;
    private Collider _collider;
    private MeshRenderer _renderer;


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

    private void Start()
    {
        InitComponents();
    }
    private void InitComponents()
    {
        _collider = GetComponent<Collider>();
        _renderer = GetComponent<MeshRenderer>();
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
