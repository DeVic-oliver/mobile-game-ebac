using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Level
{
    public class LevelGenerator : MonoBehaviour
    {

        [SerializeField] private Transform _levelContainerTransform;
        [SerializeField] private List<GameObject> _levelPiecesList;
        [SerializeField] private GameObject _startLevelPiece;
        [SerializeField] private GameObject _endLevelPiece;

        [SerializeField] private int _piecesToGenerate;

        private GameObject _lastPieceInstatiated;

        private void Start()
        {
            _lastPieceInstatiated = Instantiate(_startLevelPiece, _levelContainerTransform);

            InstatiateAllPieces();
        }
        private void InstatiateAllPieces()
        {
            for (int i = 0; i < _piecesToGenerate; i++)
            {

                GameObject pieceChoosed = GetRandomPieceOfList();

                pieceChoosed.transform.localPosition = GetNewPositionToThePiece();

                Instantiate(pieceChoosed, _levelContainerTransform);

                _lastPieceInstatiated = pieceChoosed;
            }
        }
        private GameObject GetRandomPieceOfList()
        {
            return _levelPiecesList[Random.Range(0, _levelPiecesList.Count)];
        }
        private Vector3 GetNewPositionToThePiece()
        {
            return new Vector3(0, 0, _lastPieceInstatiated.transform.localPosition.z + 10);
        }
    }
}
