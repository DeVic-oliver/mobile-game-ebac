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
            SetStartPiece();

            SetMiddlePieces();

            SetEndPiece();
        }

        private void SetStartPiece()
        {
            _lastPieceInstatiated = Instantiate(_startLevelPiece, _levelContainerTransform);
        }

        private void SetMiddlePieces()
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
            
            return _lastPieceInstatiated.GetComponent<LevelPiece>().Endpoint.transform.position;
        }

        private void SetEndPiece()
        {
            _endLevelPiece.transform.position = GetNewPositionToThePiece();

            Instantiate(_endLevelPiece, _levelContainerTransform);
        }
    }
}
