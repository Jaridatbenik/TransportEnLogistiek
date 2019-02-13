using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileTypes
{
    standardTile,
    firstTestTile,
    secondTestTile,
    thirdTestTile,
    FourthTestTile,
    FifthTestTile
}

public class TileStorage : MonoBehaviour
{
    public static List<Tile> availableTiles = new List<Tile>()
    {
        { new Tile((int)TileTypes.standardTile) },
        { new Tile((int)TileTypes.firstTestTile) },
        { new Tile((int)TileTypes.secondTestTile) },
        { new Tile((int)TileTypes.thirdTestTile) },
        { new Tile((int)TileTypes.FourthTestTile) },
        { new Tile((int)TileTypes.FifthTestTile) }
    };

    public static List<bool> needsUpdate = new List<bool>()
    {
        { false }, //TileTypes.standardTile
        { false }, //TileTypes.firstTestTile
        { false }, //TileTypes.secondTestTile
        { false }, //TileTypes.thirdTestTile
        { true }, //TileTypes.FourthTestTile
        { false }  //TileTypes.FifthTestTile
    };

}
