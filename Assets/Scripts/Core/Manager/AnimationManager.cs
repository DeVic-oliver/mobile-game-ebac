using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Core.Manager
{
    public class AnimationManager : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void TriggerAnimation(string animationID)
        {
            _animator.SetTrigger(animationID);
        }
    }
}