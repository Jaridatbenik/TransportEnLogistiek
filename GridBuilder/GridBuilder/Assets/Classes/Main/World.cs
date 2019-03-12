using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PositionMode
{
    ActualPosition,
    SingleDigitMode
}

public static class World
{
    public static List<Chunk> worldChunks = new List<Chunk>();
    public static Vector2Int worldSize = new Vector2Int(0, 0);

    public static Chunk GetChunk(Vector2Int worldPosition)
    {
        for (int i = 0; i < worldChunks.Count; i++)
        {
            if (worldPosition.x >= worldChunks[i].positionClampers.x &&
                worldPosition.x < worldChunks[i].positionClampers.x + StaticGameValues.chunkSize &&
                worldPosition.y >= worldChunks[i].positionClampers.y &&
                worldPosition.y < worldChunks[i].positionClampers.y + StaticGameValues.chunkSize)
            {
                return worldChunks[i];
            }
        }
        return null;
    }
    /// <summary>
    /// Use this method to create a chunk for tiles
    /// </summary>
    /// <param name="posx">start position x</param>
    /// <param name="posy">start position y</param>
    /// <param name="mode">the mode determines how to position will be calculated</param>
    public static Chunk CreateChunk(int posx, int posy, PositionMode mode)
    {
        Chunk chunktemp;
        if(mode == PositionMode.ActualPosition)
        {
            chunktemp =  new Chunk(new Vector2Int(posx, posy));
            worldChunks.Add(chunktemp);
            return chunktemp;
        }
        else if(mode == PositionMode.SingleDigitMode)
        {
            chunktemp = new Chunk(new Vector2Int(posx * StaticGameValues.chunkSize, posy * StaticGameValues.chunkSize));
            worldChunks.Add(chunktemp);
            return chunktemp;
        }
        return null;
    } 

    /// <summary>
       /// Use this method to create a chunk for tiles
       /// </summary>
       /// <param name="posx">start position x</param>
       /// <param name="posy">start position y</param>
       /// <param name="tiles">tiles you want to populate the chunk with</param>
       /// <param name="mode">the mode determines how to position will be calculated</param>
    public static Chunk CreateChunk(int posx, int posy, Tile[,] tiles, PositionMode mode)
    {
        Chunk chunktemp;
        if (mode == PositionMode.ActualPosition)
        {
            chunktemp = new Chunk(new Vector2Int(posx, posy), tiles);
            worldChunks.Add(chunktemp);
            return chunktemp;
        }
        else if (mode == PositionMode.SingleDigitMode)
        {
            chunktemp = new Chunk(new Vector2Int(posx * StaticGameValues.chunkSize, posy * StaticGameValues.chunkSize), tiles);
            worldChunks.Add(chunktemp);
            return chunktemp;
        }
        return null;
    }

    public static Tile GetTile(Vector2Int worldPosition)
    {
        Chunk chunk = GetChunk(worldPosition);
        return chunk.GetTile(worldPosition.x - chunk.positionClampers.x, worldPosition.y - chunk.positionClampers.y);

    }

    public static void SetTile(Vector2Int worldPosition, Tile tile)
    {
        Chunk chunk = GetChunk(worldPosition);
        chunk.SetTile(worldPosition.x - chunk.positionClampers.x, worldPosition.y - chunk.positionClampers.y, tile);
    }
}
