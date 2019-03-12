using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class TileGameObject : MonoBehaviour
{
    public Tile assosiatedTile;
    TileUpdateHandler updateHandler;
    SpriteRenderer sprite;
    List<GameObject> customTileData = new List<GameObject>();

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        UpdateTileToID(assosiatedTile.tileID);
    }

    void AddUpdateHandler()
    {
        RemoveUpdateHandler();
        updateHandler = gameObject.AddComponent<TileUpdateHandler>();
        updateHandler.obj = GetComponent<TileGameObjectEventHandler>();
    }

    void RemoveUpdateHandler()
    {
        updateHandler = null;
        Destroy(gameObject.GetComponent<TileUpdateHandler>());
    }

    void SpawnTileHandlers()
    {
        RemoveSpawnedTileHandlers();

        for(int i = 0; i < assosiatedTile.customTileData.Count; i++)
        {
            GameObject obj = Instantiate(assosiatedTile.customTileData[i], transform, true);
            obj.transform.position = gameObject.transform.position;
            customTileData.Add(obj);
        }
    }

    void RemoveSpawnedTileHandlers()
    {
        for(int i = 0; i < customTileData.Count; i++)
        {
            Destroy(customTileData[i]);
        }
        customTileData.Clear();
    }

    public void UpdateTileToID(int id)
    {
        OverwriteTileGameObject(new Tile(TileStorageHandler.GetTileFromID(id)));
        UpdateTileGraphics();
        SpawnTileHandlers();
        if (assosiatedTile.needsUpdate)
        {
            AddUpdateHandler();
        }else
        {
            RemoveUpdateHandler();
        }
    }

    public void UpdateTileGraphics()
    {
        if(sprite == null)
        {
            sprite = GetComponent<SpriteRenderer>();
        }
        try
        {
            sprite.sprite = assosiatedTile.tileSprite;
        }catch
        {
            Debug.Log("Sprite for tileID : " + assosiatedTile.tileID + " was not found");
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

    public GameObject OverwriteTileGameObject(Tile tile)
    {
        GameObject tileObject = gameObject;
        //Debug.Log("voor : "+ World.GetTile(new Vector2Int((int)transform.position.y, (int)transform.position.x)).tileID);
        tileObject.GetComponent<TileGameObject>().assosiatedTile = tile;
        tile.associatesWithThisGameObject = tileObject.GetComponent<TileGameObject>();
        World.SetTile(new Vector2Int((int)transform.position.y, (int)transform.position.x), tile);
        //Debug.Log("na : " + World.GetTile(new Vector2Int((int)transform.position.y, (int)transform.position.x)).tileID);
        return tileObject;
    }
}
