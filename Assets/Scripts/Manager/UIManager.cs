using System.Collections;
using UnityEngine;

namespace Assets.Scripts.SceneManager
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject _endScreen;


        private void Start()
        {
            _endScreen.SetActive(false);
        }

        public void ShowEndScreen()
        {
            _endScreen.SetActive(true);
        }
    }
}