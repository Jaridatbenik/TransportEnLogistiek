using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public int tileID;
    public List<GameObject> customTileData = new List<GameObject>();
    public TileGameObject associatesWithThisGameObject;
    public Chunk isInChunk;
    public Inventory inv;
    public bool needsUpdate = false;
    public Sprite tileSprite;

    #region Constructors without inventory;
    /// <summary>
    /// Constructor of the Tile
    /// </summary>
    /// <param name="ID">ID of the tile</param>
    public Tile(int ID)
    {
        tileID = ID;
    }

    /// <summary>
    /// Constructor of the Tile
    /// </summary>
    /// <param name="ID">ID of the tile</param>
    /// <param name="data">If there is custom data pass it here</param>
    public Tile(int ID, GameObject data)
    {
        tileID = ID;
        customTileData.Add(data);
    }

    /// <summary>
    /// Constructor of the Tile
    /// </summary>
    /// <param name="ID">ID of the tile</param>
    /// <param name="data">If there is custom data pass it here</param>
    public Tile(int ID, List<GameObject> data)
    {
        tileID = ID;
        customTileData = data;
    }

    public Tile(int ID, List<GameObject> data, bool needsUpdate, Sprite sprite)
    {
        tileID = ID;
        customTileData = data;
        this.needsUpdate = needsUpdate;
        this.tileSprite = sprite;
    }

    /// <summary>
    /// Constructor of the Tile
    /// </summary>
    /// <param name="ID">ID of the tile</param>
    public Tile(int ID, TileGameObject assosiateWithThis)
    {
        tileID = ID;
        associatesWithThisGameObject = assosiateWithThis;
    }

    /// <summary>
    /// Constructor of the Tile
    /// </summary>
    /// <param name="ID">ID of the tile</param>
    /// <param name="data">If there is custom data pass it here</param>
    public Tile(int ID, GameObject data, TileGameObject assosiateWithThis)
    {
        tileID = ID;
        customTileData.Add(data);
        associatesWithThisGameObject = assosiateWithThis;
    }

    /// <summary>
    /// Constructor of the Tile
    /// </summary>
    /// <param name="ID">ID of the tile</param>
    /// <param name="data">If there is custom data pass it here</param>
    public Tile(int ID, List<GameObject> data, TileGameObject assosiateWithThis)
    {
        tileID = ID;
        customTileData = data;
        associatesWithThisGameObject = assosiateWithThis;
    }

    /// <summary>
    /// Constructor of the Tile
    /// </summary>
    /// <param name="ID">ID of the tile</param>
    public Tile(int ID, Chunk chunk)
    {
        tileID = ID;
        isInChunk = chunk;
    }

    /// <summary>
    /// Constructor of the Tile
    /// </summary>
    /// <param name="ID">ID of the tile</param>
    /// <param name="data">If there is custom data pass it here</param>
    public Tile(int ID, GameObject data, Chunk chunk)
    {
        tileID = ID;
        customTileData.Add(data);
        isInChunk = chunk;
    }

    /// <summary>
    /// Constructor of the Tile
    /// </summary>
    /// <param name="ID">ID of the tile</param>
    /// <param name="data">If there is custom data pass it here</param>
    public Tile(int ID, List<GameObject> data, Chunk chunk)
    {
        tileID = ID;
        customTileData = data;
        isInChunk = chunk;
    }

    /// <summary>
    /// Constructor of the Tile
    /// </summary>
    /// <param name="ID">ID of the tile</param>
    public Tile(int ID, TileGameObject assosiateWithThis, Chunk chunk)
    {
        tileID = ID;
        associatesWithThisGameObject = assosiateWithThis;
        isInChunk = chunk;
    }

    /// <summary>
    /// Constructor of the Tile
    /// </summary>
    /// <param name="ID">ID of the tile</param>
    /// <param name="data">If there is custom data pass it here</param>
    public Tile(int ID, GameObject data, TileGameObject assosiateWithThis, Chunk chunk)
    {
        tileID = ID;
        customTileData.Add(data);
        associatesWithThisGameObject = assosiateWithThis;
        isInChunk = chunk;
    }

    /// <summary>
    /// Constructor of the Tile
    /// </summary>
    /// <param name="ID">ID of the tile</param>
    /// <param name="data">If there is custom data pass it here</param>
    public Tile(int ID, List<GameObject> data, TileGameObject assosiateWithThis, Chunk chunk)
    {
        tileID = ID;
        customTileData = data;
        associatesWithThisGameObject = assosiateWithThis;
        isInChunk = chunk;
    }

    public Tile(Tile tile)
    {
        this.tileID = tile.tileID;
        this.customTileData = tile.customTileData;
        this.associatesWithThisGameObject = tile.associatesWithThisGameObject;
        this.needsUpdate = tile.needsUpdate;
        this.tileSprite = tile.tileSprite;
        this.inv = tile.inv;
    }
    #endregion

    #region Constructors with inventory;
    /// <summary>
    /// Constructor of the Tile
    /// </summary>
    /// <param name="ID">ID of the tile</param>
    public Tile(int ID, Inventory inv)
    {
        tileID = ID;
        this.inv = inv;
    }

    /// <summary>
    /// Constructor of the Tile
    /// </summary>
    /// <param name="ID">ID of the tile</param>
    /// <param name="data">If there is custom data pass it here</param>
    public Tile(int ID, GameObject data, Inventory inv)
    {
        tileID = ID;
        customTileData.Add(data);
        this.inv = inv;
    }

    /// <summary>
    /// Constructor of the Tile
    /// </summary>
    /// <param name="ID">ID of the tile</param>
    /// <param name="data">If there is custom data pass it here</param>
    public Tile(int ID, List<GameObject> data, Inventory inv)
    {
        tileID = ID;
        customTileData = data;
        this.inv = inv;
    }

    /// <summary>
    /// Constructor of the Tile
    /// </summary>
    /// <param name="ID">ID of the tile</param>
    public Tile(int ID, TileGameObject assosiateWithThis, Inventory inv)
    {
        tileID = ID;
        associatesWithThisGameObject = assosiateWithThis;
        this.inv = inv;
    }

    /// <summary>
    /// Constructor of the Tile
    /// </summary>
    /// <param name="ID">ID of the tile</param>
    /// <param name="data">If there is custom data pass it here</param>
    public Tile(int ID, GameObject data, TileGameObject assosiateWithThis, Inventory inv)
    {
        tileID = ID;
        customTileData.Add(data);
        associatesWithThisGameObject = assosiateWithThis;
        this.inv = inv;
    }

    /// <summary>
    /// Constructor of the Tile
    /// </summary>
    /// <param name="ID">ID of the tile</param>
    /// <param name="data">If there is custom data pass it here</param>
    public Tile(int ID, List<GameObject> data, TileGameObject assosiateWithThis, Inventory inv)
    {
        tileID = ID;
        customTileData = data;
        associatesWithThisGameObject = assosiateWithThis;
        this.inv = inv;
    }

    /// <summary>
    /// Constructor of the Tile
    /// </summary>
    /// <param name="ID">ID of the tile</param>
    public Tile(int ID, Chunk chunk, Inventory inv)
    {
        tileID = ID;
        isInChunk = chunk;
        this.inv = inv;
    }

    /// <summary>
    /// Constructor of the Tile
    /// </summary>
    /// <param name="ID">ID of the tile</param>
    /// <param name="data">If there is custom data pass it here</param>
    public Tile(int ID, GameObject data, Chunk chunk, Inventory inv)
    {
        tileID = ID;
        customTileData.Add(data);
        isInChunk = chunk;
        this.inv = inv;
    }

    /// <summary>
    /// Constructor of the Tile
    /// </summary>
    /// <param name="ID">ID of the tile</param>
    /// <param name="data">If there is custom data pass it here</param>
    public Tile(int ID, List<GameObject> data, Chunk chunk, Inventory inv)
    {
        tileID = ID;
        customTileData = data;
        isInChunk = chunk;
        this.inv = inv;
    }

    /// <summary>
    /// Constructor of the Tile
    /// </summary>
    /// <param name="ID">ID of the tile</param>
    public Tile(int ID, TileGameObject assosiateWithThis, Chunk chunk, Inventory inv)
    {
        tileID = ID;
        associatesWithThisGameObject = assosiateWithThis;
        isInChunk = chunk;
        this.inv = inv;
    }

    /// <summary>
    /// Constructor of the Tile
    /// </summary>
    /// <param name="ID">ID of the tile</param>
    /// <param name="data">If there is custom data pass it here</param>
    public Tile(int ID, GameObject data, TileGameObject assosiateWithThis, Chunk chunk, Inventory inv)
    {
        tileID = ID;
        customTileData.Add(data);
        associatesWithThisGameObject = assosiateWithThis;
        isInChunk = chunk;
        this.inv = inv;
    }

    /// <summary>
    /// Constructor of the Tile
    /// </summary>
    /// <param name="ID">ID of the tile</param>
    /// <param name="data">If there is custom data pass it here</param>
    public Tile(int ID, List<GameObject> data, TileGameObject assosiateWithThis, Chunk chunk, Inventory inv)
    {
        tileID = ID;
        customTileData = data;
        associatesWithThisGameObject = assosiateWithThis;
        isInChunk = chunk;
        this.inv = inv;
    }

    public Tile(Tile tile, Inventory inv)
    {
        this.tileID = tile.tileID;
        this.customTileData = tile.customTileData;
        this.associatesWithThisGameObject = tile.associatesWithThisGameObject;
        this.inv = inv;
    }
    #endregion

    public void SetTile(int id)
    {
        associatesWithThisGameObject.UpdateTileToID(id);
    }

    public Inventory InventoryData
    {
        set { inv = value; }
        get { return inv; }
    }
}
