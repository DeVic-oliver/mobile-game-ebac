using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Items.Powerups.Buffs
{
    public class PowerupSpeed : PowerupBase
    {
        [SerializeField] private float rotationSpeed;

        private void Update()
        {
            DoFloatingBehaviour();
        }

        public override void DoFloatingBehaviour()
        {
            var eulers = Vector3.up * Time.deltaTime * rotationSpeed;
            transform.Rotate(eulers, Space.World);
        }

    }
}