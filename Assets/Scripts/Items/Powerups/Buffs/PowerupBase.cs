using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Core.Interfaces;

namespace Assets.Scripts.Items.Powerups
{
    public abstract class PowerupBase : MonoBehaviour, IBuffable
    {
        
        [Range(0f, 1f)]
        [SerializeField] private float _buffMultplierPercentage;

        [SerializeField] private float _buffTimer;

        private float _timerToDisable = 2f;

        private MeshRenderer _meshRenderer;


        private void Start()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        public abstract void DoFloatingBehaviour();

        public float GetBuffedValue(float valueToBeBuffed)
        {
            StartCoroutine("DisablePowerUp");
            var buffedValue = valueToBeBuffed * _buffMultplierPercentage;
            return buffedValue + valueToBeBuffed;
        }

        public int GetBuffedValue(int valueToBeBuffed)
        {
            StartCoroutine("DisablePowerUp");
            var buffedValue = Mathf.RoundToInt( valueToBeBuffed * _buffMultplierPercentage );
            return buffedValue + valueToBeBuffed;
        }

        public float GetBuffTimer()
        {
            return _buffTimer;
        }

        private IEnumerator DisablePowerUp()
        {
            _meshRenderer.enabled = false;
            yield return new WaitForSeconds(_timerToDisable);
            gameObject.SetActive(false);
        }
    }
}

