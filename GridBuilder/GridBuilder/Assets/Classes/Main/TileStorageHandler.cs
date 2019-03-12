using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileStorageHandler : MonoBehaviour
{

    public static Dictionary<int, Tile> tileStorage = new Dictionary<int, Tile>();

    List<GameObject> tileObjects = new List<GameObject>();

    void Start()
    {
        GameObject[] loadedObjects = (GameObject[])Resources.LoadAll<GameObject>("TileData") as GameObject[];

        for (int i = 0; i < loadedObjects.Length; i++)
        {
            tileObjects.Add(loadedObjects[i] as GameObject);

            TileEditorData data = loadedObjects[i].GetComponent<TileEditorData>();
            tileStorage.Add(data.ID, new Tile(data.ID, MakeListFromArray<GameObject>(data.CUSTOMSCRIPTS), data.NEEDSUPDATE, data.SPRITE));

        }
    }

    public static Tile GetTileFromID(int id)
    {
        return tileStorage[id];
    }

    public static List<T> MakeListFromArray<T>(T[] arrayin)
    {
        List<T> temp = new List<T>();
        for(int i = 0; i < arrayin.Length; i++)
        {
            temp.Add(arrayin[i]);
        }
        return temp;
    }
}
