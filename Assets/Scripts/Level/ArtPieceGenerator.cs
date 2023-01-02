using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtPieceGenerator : MonoBehaviour
{
    public SCP_ArtPieces ArtPieceSetup;

    private GameObject _artPiecesContainer;
    private List<Vector3> _coordinatesToInstantiate = new List<Vector3>();
    private Color _selectedColor;


    private void Start()
    {
        _selectedColor = ArtPieceSetup.ArtPieceColor[Random.Range(0, ArtPieceSetup.ArtPieceColor.Count)];

        InitCoordinatesForArtiPieces();

        CreateArtPiecesContainer();

        PopulateArtPiecesContainer();
    }
    private void InitCoordinatesForArtiPieces()
    {
        _coordinatesToInstantiate.Add(new Vector3(5, .3f, 2));
        _coordinatesToInstantiate.Add(new Vector3(5, .3f, -2));
        _coordinatesToInstantiate.Add(new Vector3(-5, .3f, 2));
        _coordinatesToInstantiate.Add(new Vector3(-5, .3f, -2));
    }
    private void CreateArtPiecesContainer()
    {
        _artPiecesContainer = Instantiate(new GameObject("ArtPiecesContainer"), transform);
        _artPiecesContainer.transform.localPosition = Vector3.zero;
    }
    private void PopulateArtPiecesContainer()
    {
        foreach (var coordinate in _coordinatesToInstantiate)
        {
            var art = Instantiate(ArtPieceSetup.ArtPieceForPlaceholder, _artPiecesContainer.transform);
            art.GetComponent<MeshRenderer>().material.color = _selectedColor;
            art.transform.localPosition = coordinate;
        }
    }
}
