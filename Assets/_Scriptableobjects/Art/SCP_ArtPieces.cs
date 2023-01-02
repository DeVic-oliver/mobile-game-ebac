using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ArtPiecesSetup", menuName = "ScriptableObjects/Art/ArtPiecesSetup")]
public class SCP_ArtPieces : ScriptableObject
{
    public GameObject ArtPieceForPlaceholder;
    public List<Color> ArtPieceColor;
}