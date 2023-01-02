using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtPiece : MonoBehaviour
{
    public SCP_ArtPieces ArtPieceSetup;

    private List<Vector3> _coordinatesToInstantiate = new List<Vector3>();
    private Color _selectedColor;

    private void Start()
    {
        transform.localPosition = Vector3.zero;
        _selectedColor = ArtPieceSetup.ArtPieceColor[Random.Range(0, ArtPieceSetup.ArtPieceColor.Count)];
        _coordinatesToInstantiate.Add(new Vector3(5, .3f, 2));
        _coordinatesToInstantiate.Add(new Vector3(5, .3f, -2));
        _coordinatesToInstantiate.Add(new Vector3(-5, .3f, 2));
        _coordinatesToInstantiate.Add(new Vector3(-5, .3f, -2));


        foreach(var coordinate in _coordinatesToInstantiate)
        {
            var art = Instantiate(ArtPieceSetup.ArtPieceForPlaceholder, transform);
            art.GetComponent<MeshRenderer>().material.color = _selectedColor;
            art.transform.localPosition = coordinate;
        }
    }
}
