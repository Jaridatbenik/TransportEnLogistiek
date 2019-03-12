using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.IO;

public class TileEditor : EditorWindow
{
    static EditorWindow window;
    static string path = "TileData";

    static List<GameObject> tileData = new List<GameObject>();

    static Vector2 tileSize = new Vector2(100, 100);

    static float size = 100;

    static bool refreshAtEnd = false;

    static bool showTileEditor = false;

    static GameObject loadedData;

    static GameObject[] objects;
    static List<GameObject> filteredObjects = new List<GameObject>();

    static bool tickonce = false;
    SerializedObject serializedObj;
    ReorderableList list;

    [MenuItem("Tile Editor/Open Editor")]
    public static void OpenWindow()
    {
        CreateWindow();
    }

    public static void CreateWindow()
    {

        if (window == null)
        {
            window = EditorWindow.GetWindow(typeof(TileEditor));
            window.Show();
            window.minSize = new Vector2(240, 500);
            Rewrite();
            Refresh();
        }
        else
        {
            Debug.Log("there already is a window");
        }
    }

    static void Save(GameObject overWriteObject, TileEditorData data)
    {

            int overwriteid = data.OVERWRITEID;
            TileEditorData dat = overWriteObject.GetComponent<TileEditorData>();

            AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(overWriteObject), "TileObject" + (overwriteid));
            dat.ID = data.OVERWRITEID;
            dat.NEEDSUPDATE = data.NEEDSUPDATE;
            dat.SPRITE = data.SPRITE;
            dat.CUSTOMSCRIPTS = data.CUSTOMSCRIPTS;
            dat.TILETITLE = data.TILETITLE;
            PrefabUtility.SavePrefabAsset(overWriteObject.gameObject);
        
        //"Assets/Resources/TileData/TileObject" + (i + 1).ToString() + ".prefab"


    }
    static void Refresh()
    {
        path = path.Replace("&BaseAssets&", Application.dataPath);
        tileData.Clear();
        showTileEditor = false;
        tickonce = false;

        objects = Resources.LoadAll<GameObject>(path);
        filteredObjects.Clear();
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].GetComponent<TileEditorData>() != null)
            {
                filteredObjects.Add(objects[i]);
                tileData.Add(objects[i]);
            }
        }
    }

    static void Rewrite()
    {
        objects = Resources.LoadAll<GameObject>(path);

        for (int i = 0; i < objects.Length; i++)
        {
            int overwriteid = objects[i].GetComponent<TileEditorData>().OVERWRITEID;
            if (overwriteid <= -1)
            {
                AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(objects[i]), "TileObject" + (i + 1));
                objects[i].GetComponent<TileEditorData>().ID = i;
                PrefabUtility.SavePrefabAsset(objects[i].gameObject);
            }
            else
            {
                AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(objects[i]), "TileObject" + (overwriteid + 1));
                objects[i].GetComponent<TileEditorData>().ID = overwriteid;
                PrefabUtility.SavePrefabAsset(objects[i].gameObject);
            }
        }
    }

    Vector2 scrollPos = new Vector2();

    void OnGUI()
    {
        GUILayout.BeginVertical();

        if (!showTileEditor)
        {
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Refresh", GUILayout.Width(120)))
            {
                Refresh();
            }
            if (GUILayout.Button("Rewrite", GUILayout.Width(120)))
            {
                Rewrite();
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Size: ", GUILayout.MaxWidth(40));
            size = GUILayout.HorizontalSlider(tileSize.x, 50, 200, GUILayout.MaxWidth(150));
            if (GUILayout.Button("Reset Size"))
            {
                size = 100;
            }
            tileSize.x = size;
            tileSize.y = size;

            GUILayout.EndHorizontal();

            scrollPos = GUILayout.BeginScrollView(scrollPos, GUILayout.Height(window.position.size.y - 100), GUILayout.Width(window.position.size.x - 5));
            GUILayout.BeginVertical(EditorStyles.helpBox, GUILayout.MaxHeight(window.position.size.y - 100), GUILayout.MaxWidth(window.position.size.x - 5));
            SpawnObjects();
            GUILayout.EndVertical();
            GUILayout.EndScrollView();
        }
        else
        {
            if (GUILayout.Button("Back", GUILayout.Width(120)))
            {
                Refresh();
            }

            TileEditorData data = loadedData.GetComponent<TileEditorData>();

            

            GUILayout.BeginVertical(EditorStyles.helpBox, GUILayout.MaxHeight(window.position.size.y - 100), GUILayout.MaxWidth(window.position.size.x - 5));

            GUILayout.BeginHorizontal(EditorStyles.helpBox, GUILayout.MaxHeight(25), GUILayout.MaxWidth(window.position.size.x - 5));
            GUILayout.Label("Tile ID = ", GUILayout.MaxWidth(90));
            GUILayout.Label(data.ID.ToString(), GUILayout.MaxWidth(60));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal(EditorStyles.helpBox, GUILayout.MaxHeight(25), GUILayout.MaxWidth(window.position.size.x - 5));
            GUILayout.Label("Overwrite ID = ", GUILayout.MaxWidth(90));
            data.OVERWRITEID = int.Parse(GUILayout.TextField(data.OVERWRITEID.ToString(), GUILayout.MaxWidth(200)));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal(EditorStyles.helpBox, GUILayout.MaxHeight(25), GUILayout.MaxWidth(window.position.size.x - 5));
            GUILayout.Label("Tile Name = ", GUILayout.MaxWidth(90));
            data.TILETITLE = GUILayout.TextField(data.TILETITLE.ToString(), GUILayout.MaxWidth(200));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal(EditorStyles.helpBox, GUILayout.MaxWidth(400));
            data.SPRITE = (Sprite)EditorGUILayout.ObjectField("Sprite", data.SPRITE, typeof(Sprite), allowSceneObjects: false);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal(EditorStyles.helpBox, GUILayout.MaxHeight(25), GUILayout.MaxWidth(window.position.size.x - 5));
            GUILayout.Label("needs update", GUILayout.MaxWidth(90));
            data.NEEDSUPDATE = EditorGUILayout.Toggle(data.NEEDSUPDATE);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal(EditorStyles.helpBox, GUILayout.MaxHeight(200), GUILayout.MaxWidth(window.position.size.x - 5));
            //additional data
            GUILayout.BeginVertical();
            if (tickonce)
            {
                tickonce = false;
                serializedObj = new SerializedObject(data);
                list = new ReorderableList(serializedObj, serializedObj.FindProperty("customScripts"), true, true, true, true);


                list.drawHeaderCallback = (rect) => EditorGUI.LabelField(rect, "custom Scripts");
                list.drawElementCallback = (Rect rect1, int index, bool isActive, bool isFocused) =>
                {
                    rect1.y += 2;
                    rect1.height = EditorGUIUtility.singleLineHeight;
                    //EditorGUI.PropertyField(rect1, list.serializedProperty.GetArrayElementAtIndex(index), false);
                    data.customScripts[index] = (GameObject)EditorGUI.ObjectField(rect1, data.customScripts[index], typeof(GameObject), allowSceneObjects: false);
                };
            }

            serializedObj.Update();
            list.DoLayoutList();
            serializedObj.ApplyModifiedProperties();

            if (GUILayout.Button("Save", GUILayout.Width(120)))
            {
                Save(objects[tileData.IndexOf(data.gameObject)], data);
                Refresh();
            }
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();


            GUILayout.EndVertical();
        }
        GUILayout.EndVertical();
    }

    static void SpawnObjects()
    {
        int amountpassed = 0;
        int lastamountpassed = -1;
        int f = 0;
        for (int i = 0; i <= tileData.Count; i++)
        {
            f++;
            if (lastamountpassed != amountpassed)
            {
                GUILayout.BeginHorizontal();
                lastamountpassed = amountpassed;
            }
            GUILayout.BeginHorizontal(EditorStyles.helpBox, GUILayout.MaxHeight(tileSize.y), GUILayout.MaxWidth(tileSize.x));
            if (i != tileData.Count)
            {
                GUILayout.BeginVertical();
                SpawnObject(i, false);
                try
                {
                    tileData[i].GetComponent<TileEditorData>().TILETITLE = GUILayout.TextField(tileData[i].GetComponent<TileEditorData>().TILETITLE, GUILayout.MaxWidth(90));
                }
                catch { }
                GUILayout.EndVertical();
                GUILayout.EndHorizontal();
            }
            else
            {
                SpawnObject(i, true);
            }


            if ((f + 1) * tileSize.x >= window.position.size.x)
            {
                amountpassed++;
                f = 0;
                GUILayout.EndHorizontal();
            }
        }
        GUILayout.EndVertical();

        if (refreshAtEnd)
        {
            refreshAtEnd = false;
            Refresh();
        }
    }

    static Texture2D ConvertSpriteToTexture(Sprite sprite)
    {
        try
        {
            if (sprite.rect.width != sprite.texture.width)
            {
                Texture2D newText = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
                Color[] colors = newText.GetPixels();
                Color[] newColors = sprite.texture.GetPixels((int)System.Math.Ceiling(sprite.textureRect.x),
                                                             (int)System.Math.Ceiling(sprite.textureRect.y),
                                                             (int)System.Math.Ceiling(sprite.textureRect.width),
                                                             (int)System.Math.Ceiling(sprite.textureRect.height));
                newText.SetPixels(newColors);
                newText.Apply();
                return newText;
            }
            else
                return sprite.texture;
        }
        catch
        {
            return null;
        }
    }

    static void SpawnObject(int i, bool isPlusButton)
    {
        if (!isPlusButton)
        {
            try
            {
                TileEditorData data = tileData[i].GetComponent<TileEditorData>();
                string idstring = data.ID.ToString();
                string overwriteidstring = data.OVERWRITEID.ToString();
                Sprite sprite = data.SPRITE;
                Texture2D tex = null;
                tex = ConvertSpriteToTexture(sprite);

                GUILayout.BeginHorizontal();
                if (tex != null)
                {
                    if (GUILayout.Button(tex, GUILayout.MinHeight((tileSize.y / 100) * 60), GUILayout.MinWidth((tileSize.x / 100) * 60)))
                    {
                        OnEditButtonPress(i);
                    }
                }
                else
                {
                    if (GUILayout.Button("Edit", GUILayout.MinHeight((tileSize.y / 100) * 60), GUILayout.MinWidth((tileSize.x / 100) * 60)))
                    {
                        OnEditButtonPress(i);
                    }
                }
                GUILayout.BeginVertical();
                if (GUILayout.Button("X"))
                {
                    SpawnObject(i, true);
                    AssetDatabase.DeleteAsset(AssetDatabase.GetAssetPath(filteredObjects[i]));
                    refreshAtEnd = true;
                }

                try
                {
                    GUILayout.Label(idstring);
                    tileData[i].GetComponent<TileEditorData>().OVERWRITEID = int.Parse(GUILayout.TextField(overwriteidstring));
                }
                catch { }
                GUILayout.EndVertical();
                GUILayout.EndHorizontal();
            }
            catch { }
        }
        else
        {
            if (GUILayout.Button("+", GUILayout.MinHeight((tileSize.y / 100) * 95), GUILayout.MinWidth((tileSize.x / 100) * 95)))
            {
                AddNewGameObject(i);
            }
        }
    }

    static void OnEditButtonPress(int i)
    {
        tickonce = true;
        loadedData = tileData[i];
        showTileEditor = true;
    }

    static void AddNewGameObject(int i)
    {
        GameObject obj = new GameObject((i + 1).ToString());
        obj.AddComponent<TileEditorData>();
        Debug.Log(i);
        obj.GetComponent<TileEditorData>().ID = i;
        obj.GetComponent<TileEditorData>().OVERWRITEID = i;
        obj.GetComponent<TileEditorData>().TILETITLE = "TileObject" + i;

        PrefabUtility.SaveAsPrefabAsset(obj, "Assets/Resources/TileData/TileObject" + (i + 1).ToString() + ".prefab");
        DestroyImmediate(obj);
        refreshAtEnd = true;
        Debug.Log("should add new");
    }
}
