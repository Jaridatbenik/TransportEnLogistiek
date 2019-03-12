using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileEditorData : MonoBehaviour
{
    [SerializeField]
    int id = 0;
    [SerializeField]
    string tileTitle;
    [SerializeField]
    int overwriteid = 0;
    [SerializeField]
    Sprite sprite;
    [SerializeField]
    bool needsUpdate;
    public GameObject[] customScripts;

    public int ID
    {
        get { return id; }
        set { id = value; }
    }

    public int OVERWRITEID
    {
        get { return overwriteid; }
        set { overwriteid = value; }
    }

    public string TILETITLE
    {
        get { return tileTitle; }
        set { tileTitle = value; }
    }

    public Sprite SPRITE
    {
        get { return sprite; }
        set { sprite = value; }
    }

    public bool NEEDSUPDATE
    {
        get { return needsUpdate; }
        set { needsUpdate = value; }
    }

    public GameObject[] CUSTOMSCRIPTS
    {
        get { return customScripts; }
        set { customScripts = value; }
    }
}
