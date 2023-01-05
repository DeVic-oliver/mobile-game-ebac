using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

        private List<GameObject> _levelSpawnedPieces = new List<GameObject>();

        private void Start()
        {
            SetStartPiece();

            SetMiddlePieces();

            SetEndPiece();

            StartCoroutine(TweenChildsScalePiecesToOne());
           
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

                pieceChoosed = Instantiate(pieceChoosed, _levelContainerTransform);

                _lastPieceInstatiated = pieceChoosed;

                _levelSpawnedPieces.Add(_lastPieceInstatiated);

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

            var lastPiece = Instantiate(_endLevelPiece, _levelContainerTransform);

            _levelSpawnedPieces.Add(lastPiece);

        }


        IEnumerator TweenChildsScalePiecesToOne()
        {
            SetChildsScaleToZero();

            foreach (GameObject piece in _levelSpawnedPieces)
            {
                GameObject ground = GetChild(piece, "Ground");

                ground.transform.DOScale(1f, 0.6f).SetEase(Ease.OutBack);

                yield return new WaitForSeconds(0.1f);
            }

        }
        private void SetChildsScaleToZero()
        {
            foreach (GameObject piece in _levelSpawnedPieces)
            {
                GameObject ground = GetChild(piece, "Ground");

                ground.transform.localScale = Vector3.zero;

            }
        }
        private GameObject GetChild(GameObject parent, string childName)
        {
            var child = parent.transform.Find(childName);

            if(child != null)
            {
                return child.gameObject;
            }

            return null;
        }
    }
}
