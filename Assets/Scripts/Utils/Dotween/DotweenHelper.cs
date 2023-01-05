using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts.Utils.Dotween
{
    public static class DotweenHelper
    {
       public static void ScaleYoYo(GameObject gameObject)
        {
            gameObject.transform.DOScale(1.1f, .2f).SetEase(Ease.InOutBack).SetLoops(2, LoopType.Yoyo);
        }
    }
}