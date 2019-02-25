using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameObject tilePrefab;

    private Vector3 mouseOrigin2;


    public Transform cameraHolder;

    private float movementDragSpeed = 60f;

    void Start()
    {
        tilePrefab = Resources.Load<GameObject>("tile");
        cameraHolder = Camera.main.transform;
    }

    void Update()
    {
        #region spawnChunks
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Chunk currentChunk;
            for (int ii = 0; ii < 20; ii++)
            {
                for (int ff = 0; ff < 20; ff++)
                {
                    Tile[,] tiles = new Tile[StaticGameValues.chunkSize, StaticGameValues.chunkSize];
                    for (int i = 0; i < tiles.GetLength(0); i++)
                    {
                        for (int f = 0; f < tiles.GetLength(1); f++)
                        {

                            //int num = (int)Random.Range(1, 4);
                            int num = 4;

                            tiles[i, f] = new Tile(TileStorage.availableTiles[num]);

                        }
                    }

                    currentChunk = World.CreateChunk(ii, ff, tiles, PositionMode.SingleDigitMode);

                    Chunk.SetChunkAsParentChunk(currentChunk);
                    currentChunk?.SpawnChunkInWorld();
                    currentChunk?.DisplayChunk();
                }
            }
        }
        #endregion

        #region mouseClick
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousepositions = new Vector2(Input.mousePosition.x, Input.mousePosition.y );

            Vector2 camerapos = Camera.main.ScreenToWorldPoint(mousepositions);
            Debug.Log(mousepositions);
            Debug.Log(camerapos.x + ":" + camerapos.y);
            Debug.Log(World.GetTile(new Vector2Int(Mathf.FloorToInt(camerapos.y), Mathf.FloorToInt(camerapos.x))).associatesWithThisGameObject.name);
            World.GetTile(new Vector2Int(Mathf.FloorToInt(camerapos.y), Mathf.FloorToInt(camerapos.x))).SetTile(0);
        }
        #endregion


        #region mouseClick2
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousepositions = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            Vector2 camerapos = Camera.main.ScreenToWorldPoint(mousepositions);
            Debug.Log(mousepositions);
            Debug.Log(camerapos.x + ":" + camerapos.y);
            Debug.Log(World.GetTile(new Vector2Int(Mathf.FloorToInt(camerapos.y), Mathf.FloorToInt(camerapos.x))).associatesWithThisGameObject.name);
            World.GetTile(new Vector2Int(Mathf.FloorToInt(camerapos.y), Mathf.FloorToInt(camerapos.x))).SetTile(4);
        }
        #endregion

        #region camMove
        if (Input.GetMouseButtonDown(2))
        {
            mouseOrigin2 = Input.mousePosition;
        }

        if (Input.GetMouseButton(2))
        {
            var pos = Camera.main.ScreenToViewportPoint(mouseOrigin2 - Input.mousePosition);

            cameraHolder.position += cameraHolder.up * pos.y * movementDragSpeed;
            cameraHolder.position += cameraHolder.right * pos.x * movementDragSpeed;

            cameraHolder.position = new Vector3(
                Mathf.Clamp(cameraHolder.position.x, 0, 100),
                Mathf.Clamp(cameraHolder.position.y, 0, 100),
                Mathf.Clamp(cameraHolder.position.z, -100, -10));

            mouseOrigin2 = Input.mousePosition;
        }

        if(Input.mouseScrollDelta.y != 0)
        {
            Camera.main.orthographicSize = Camera.main.orthographicSize - Input.mouseScrollDelta.y * Time.deltaTime * 30;
        }
        #endregion
    }
}
