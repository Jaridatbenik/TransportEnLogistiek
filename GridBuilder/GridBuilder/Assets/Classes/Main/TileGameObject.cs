using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class TileGameObject : MonoBehaviour
{
    Tile assosiatedTile;
    TileUpdateHandler updateHandler;
    SpriteRenderer sprite;
    List<CustomTileData> customTileData = new List<CustomTileData>();

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        UpdateTileGraphics(assosiatedTile.tileID);
    }

    void AddUpdateHandler()
    {
        RemoveUpdateHandler();
        updateHandler = gameObject.AddComponent<TileUpdateHandler>();
        updateHandler.obj = this;
    }

    void RemoveUpdateHandler()
    {
        updateHandler = null;
        Destroy(gameObject.GetComponent<TileUpdateHandler>());
    }

    public void TileUpdate()
    {
        //Debug.Log("update");
    }

    public void TileFixedUpdate()
    {
        //Debug.Log("fixed update");
    }

    public void UpdateTileToID(int id)
    {
        UpdateTileGraphics(id);
        if (TileStorage.needsUpdate[id])
        {
            AddUpdateHandler();
        }else
        {
            RemoveUpdateHandler();
        }
    }

    public void UpdateTileGraphics(int tileID)
    {
        if(sprite == null)
        {
            sprite = GetComponent<SpriteRenderer>();
        }
        try
        {
            sprite.sprite = TileSprites.availableTileSprites[tileID];
        }catch
        {
            Debug.Log("Sprite for tileID : " + tileID + " was not found");
            sprite.sprite = null;
        }
    }

    public static GameObject CreateTileGameObject(Tile tile, int posx, int posy, int posxchunk, int posychunk)
    {
        GameObject tileObject = Instantiate(GameHandler.tilePrefab);
        tileObject.GetComponent<TileGameObject>().assosiatedTile = tile;
        tile.associatesWithThisGameObject = tileObject.GetComponent<TileGameObject>();
        tileObject.transform.localPosition = new Vector3(posy + posychunk, posx + posxchunk);
        tileObject.name = "tile" + (posx + posxchunk) + " : " + (posy + posychunk);
        return tileObject;
    }
}
