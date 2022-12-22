using System.Collections;
using UnityEngine;
namespace Assets.Scripts.SceneManager
{
    using Assets.Scripts.Player;
    using UnityEngine.SceneManagement;
    public class GameManager : MonoBehaviour
    {

        public static bool IsPlayerReachedFinishlLine { get; set; }

        private UIManager _uiManager;

        private void Awake()
        {
            IsPlayerReachedFinishlLine = false;
        }

        // Use this for initialization
        void Start()
        {
            _uiManager = GetComponent<UIManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!Player.isAlive || IsPlayerReachedFinishlLine)
            {
                _uiManager.ShowEndScreen();
                StartCoroutine("ReloadGame");
            }
        }

        private IEnumerator ReloadGame()
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}