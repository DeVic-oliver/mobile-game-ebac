using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Items.Powerups.Buffs
{
    public class SpeedBoost : PowerupBase
    {
        [SerializeField] private float rotationSpeed;

        private void Update()
        {
            DoFloatingBehaviour();
        }

        protected override void DoFloatingBehaviour()
        {
            var eulers = Vector3.up * Time.deltaTime * rotationSpeed;
            transform.Rotate(eulers, Space.World);
        }

    }
}