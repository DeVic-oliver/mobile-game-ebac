using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVFXDeath : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private bool _vfxPlayed = false;



    private void Start()
    {
        _vfxPlayed = false;
    }

    private void Update()
    {
        if (!Player.isAlive && !_vfxPlayed)
        {
            _particleSystem.Play();
            _vfxPlayed = true;
        }
    }

}
