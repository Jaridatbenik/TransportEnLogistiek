using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChunkMode
{
    /// <summary>
    /// the local position of the tile within the chunk
    /// </summary>
    localChunkPosition,
    /// <summary>
    /// the position of the tile in worldspace
    /// </summary>
    tileWorldPosition
}

public class Chunk
{
    /// <summary>
    /// 0, 0 zijn basic values, het word verwacht dat deze worden overschrijven
    /// </summary>
    public Vector2Int positionClampers = new Vector2Int(0, 0);
    /// <summary>
    /// This array stores all the tiles of this chunk
    /// </summary>
    public Tile[,] tileArray = new Tile[StaticGameValues.chunkSize, StaticGameValues.chunkSize];

    /// <summary>
    /// Create a new chunk
    /// </summary>
    /// <param name="startingPos">the position of the chunk in world space, is important for the world position of the tiles</param>
    public Chunk(Vector2Int startingPos)
    {
        positionClampers = startingPos;
    }

    /// <summary>
    /// Create a new chunk, with an array of tiles.
    /// * note that the array should be completely filled, please please fill it, otherwise just dont use this function.
    /// </summary>
    /// <param name="startingPos">the position of the chunk in world space, is important for the world position of the tiles</param>
    /// <param name="tileArray">pass an array with tiles</param>
    public Chunk(Vector2Int startingPos, Tile[,] tileArray)
    {
        positionClampers = startingPos;
        this.tileArray = tileArray;
    }

    /// <summary>
    /// Changes Tile in the Chunk
    /// This does not update the screen
    /// Please call the screen Update Function and pass this chunk,
    /// or update the whole display
    /// </summary>
    /// <param name="position">Position of the tile that should be changed</param>
    /// <param name="mode">The mode which should be used to determine the chunk</param>
    /// <param name="tileID">The tile ID what the tile will become</param>
    public void ChangeTile(Vector2Int position, ChunkMode mode, int tileID)
    {
        if (mode == ChunkMode.localChunkPosition)
        {
            //tileArray[position.x, position.y] 
        }
        else if (mode == ChunkMode.tileWorldPosition)
        {
            //tileArray[position.x - positionClampers.x, position.y - positionClampers.y]
        }
    }

    /// <summary>
    /// Changes Tile in the Chunk
    /// This does not update the screen
    /// Please call the screen Update Function and pass this chunk,
    /// or update the whole display
    /// </summary>
    /// <param name="tileToChange">The Tile that should be changed</param>
    /// <param name="tileID">The tile ID what the tile will become</param>
    public void ChangeTile(Tile tileToChange, int tileID)
    {

    }

    /// <summary>
    /// Use this to either complete override a chunk or to begin to populate a chunk, the base tile of a chunk is always 0
    /// </summary>
    /// <param name="tiles">put the tile array you want the chunk to look like in here, also please cap the arraySize at the chunkSize value, PLEASE! if you dont I will not be responsible for your mistakes</param>
    public void PopulateChunk(Tile[,] tiles)
    {
        tileArray = tiles;
    }

    /// <summary>
    /// Get the tile from the chunk, position is expected to be the local chunk position
    /// </summary>
    /// <param name="posx">position x in chunk</param>
    /// <param name="posy">position y in chunk</param>
    /// <returns>the found tile</returns>
    public Tile GetTile(int posx, int posy)
    {
        return tileArray[posx, posy];
    }

    /// <summary>
    /// Get the tile from the chunk, position is expected to be the local chunk position
    /// </summary>
    /// <param name="chunk">pass the chunk you want to get the tile from</param>
    /// <param name="posx">position x in chunk</param>
    /// <param name="posy">position y in chunk</param>
    /// <returns>the found tile</returns>
    public static Tile GetTile(Chunk chunk, int posx, int posy)
    {
        return chunk.tileArray[posx, posy];
    }

    public void SpawnChunkInWorld()
    {
        GameObject chunkObject = new GameObject("Chunk" + positionClampers.x + ":" + positionClampers.y);
        chunkObject.transform.position = new Vector2(positionClampers.x ,positionClampers.y);
        for (int i = 0; i < tileArray.GetLength(0); i++)
        {
            for (int f = 0; f < tileArray.GetLength(1); f++)
            {
                TileGameObject.CreateTileGameObject(tileArray[i, f], i, f, positionClampers.x, positionClampers.y).transform.SetParent(chunkObject.transform);
            }
        }
    }

    public void DisplayChunk()
    {
        for (int i = 0; i < tileArray.GetLength(0); i++)
        {
            for (int f = 0; f < tileArray.GetLength(1); f++)
            {
                tileArray[i, f].associatesWithThisGameObject.GetComponent<TileGameObject>().UpdateTileGraphics(tileArray[i, f].tileID);
            }
        }
    }

    public static void SetChunkAsParentChunk(Chunk chunk)
    {
        for(int i = 0; i < chunk.tileArray.GetLength(0); i++)
        {
            for (int f = 0; f < chunk.tileArray.GetLength(1); f++)
            {
                chunk.tileArray[i, f].isInChunk = chunk;
            }
        }
    }
}
