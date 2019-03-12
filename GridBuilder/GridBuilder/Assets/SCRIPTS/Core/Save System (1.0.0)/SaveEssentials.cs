using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System;


public enum SavePaths
{
    Base,
    Settings,
    Player,
    /// <summary>
    /// DONT EVER USE THIS FOR A FILE PATH, DONT YOU EVER USE IT
    /// </summary>
    AmountOfFileTypes
}


namespace SavingDownhillDeep
{
    public static class SaveEssentials
    {
        static bool saveFileLoaded = false;
        //static Hashtable hashtable = new Hashtable(); //used to be used
        static Dictionary<string, QueueValueObject> hashtable = new Dictionary<string, QueueValueObject>();
        static List<QueueValueObject> queue = new List<QueueValueObject>();

        static string jsonstring;
        static JsonData data = new JsonData();

        static string fileExtention = ".txt";

        public static string baseSavePath = "&DataPath&/StreamingAssets/Saves/";

        internal static void SaveQueue()
        {
            LoadFile();
            for (int i = 0; i < queue.Count; i++)
            {
                try
                {
                    hashtable.Add(queue[i].variableName, queue[i]);
                }
                catch { Debug.Log("Value already exists"); }
            }
            WriteTheFile(queue);
            PoofQueue();

            Debug.Log("saved");
        }

        internal static string[] ReadAllLines(string path)
        {
            string[] allLines;

            try
            {
                allLines = File.ReadAllLines(path);
            }
            catch
            {
                File.CreateText(path).Close();
                File.WriteAllLines(path, new string[2] { "[", "]" });
                allLines = File.ReadAllLines(path);
            }

            return allLines;
        }

        internal static string ReadAllText(string path)
        {
            string allLines;

            try
            {
                allLines = File.ReadAllText(path);
            }
            catch
            {
                File.CreateText(path).Close();
                File.WriteAllLines(path, new string[2] { "[", "]" });
                allLines = File.ReadAllText(path);
            }

            return allLines;
        }

        internal static void WriteTheFile(List<QueueValueObject> values)
        {
            baseSavePath = baseSavePath.Replace("&DataPath&", Application.dataPath);
            List<string> lines = new List<string>();
            string[] readLines;

            for (int fileType = 0; fileType < (int)SavePaths.AmountOfFileTypes; fileType++)
            {
                lines.Clear();
                readLines = ReadAllLines(baseSavePath + (fileType == 0 ? GetPath(SavePaths.Base) : fileType == 1 ? GetPath(SavePaths.Player) : GetPath(SavePaths.Settings)) + fileExtention);
                for (int q = 0; q < readLines.Length; q++)
                {
                    lines.Add(readLines[q]);
                }
                if (lines.Count > 0)
                {
                    for (int i = 0; i < values.Count; i++)
                    {
                        JsonMapper.RegisterExporter<float>((obj, writer) => writer.Write(Convert.ToDouble(obj)));
                        JsonMapper.RegisterImporter<double, float>(input => Convert.ToSingle(input));

                        if (values[i].specialPath == (fileType == 0 ? GetPath(SavePaths.Base) : fileType == 1 ? GetPath(SavePaths.Player) : GetPath(SavePaths.Settings)))
                        {
                            bool writeLine = true;
                            for (int f = 0; f < lines.Count; f++)
                            {
                                if ((lines[f]).Contains(values[i].variableName))
                                {
                                    writeLine = false;
                                    hashtable[values[i].variableName] = values[i];
                                    lines[f] = JsonMapper.ToJson(values[i]) + ",";
                                    break;
                                }
                            }
                            if (writeLine)
                            {

                                lines.Insert(1, JsonMapper.ToJson(values[i]) + ",");
                                try
                                {
                                    hashtable.Add(values[i].variableName, values[i]);
                                }
                                catch { }
                            }
                        }

                    }
                    File.WriteAllLines(baseSavePath + (fileType == 0 ? GetPath(SavePaths.Base) : fileType == 1 ? GetPath(SavePaths.Player) : GetPath(SavePaths.Settings)) + fileExtention, lines.ToArray());
                }
                else
                {
                    Debug.Log("amount of lines read" + lines.Count);
                }
            }
        }

        /// <summary>
        /// removes all save values from the queue
        /// </summary>
        internal static void PoofQueue()
        {
            queue = new List<QueueValueObject>();
        }

        internal static void QueueSaveValue<T>(string variableName, T value)
        {
            bool hasToOverwrite = false;
            int overwritenum = 0;
            for(int i = 0; i < queue.Count; i++)
            {
                if(queue[i].variableName == variableName)
                {
                    hasToOverwrite = true;
                    overwritenum = i;
                    break;
                }
            }
            if (hasToOverwrite)
            {
                queue[overwritenum] = new QueueValueObject(variableName, value);
            }
            else
            {
                queue.Add(new QueueValueObject(variableName, value));
            }
        }

        internal static void QueueSaveValue<T>(SavePaths path, string variableName, T value)
        {
            bool hasToOverwrite = false;
            int overwritenum = 0;
            for (int i = 0; i < queue.Count; i++)
            {
                if (queue[i].variableName == variableName)
                {
                    hasToOverwrite = true;
                    overwritenum = i;
                    break;
                }
            }
            if (hasToOverwrite)
            {
                queue[overwritenum] = new QueueValueObject(path, variableName, value);
            }
            else
            {
                queue.Add(new QueueValueObject(path, variableName, value));
            }
        }

        /// <summary>
        /// PAS GOED OP, OP HET MOMENT WORDEN DEZE VALUES NOG NIET NAAR EEN BESTAND GESCHREVEN
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="variableName"></param>
        /// <param name="value"></param>
        internal static void SaveValue<T>(string variableName, T value)
        {
            if (!saveFileLoaded) LoadFile();
            try
            {
                hashtable.Add(variableName, new QueueValueObject(SavePaths.Base, variableName, value));
            }
            catch (ArgumentException e)
            {
                hashtable[variableName] = new QueueValueObject(SavePaths.Base, variableName, value);
                Debug.Log(e.ToString());
            }
            WriteTheFile(new List<QueueValueObject>() { hashtable[variableName] });
            Debug.Log((T)hashtable[variableName].value);
        }

        /// <summary>
        /// PAS GOED OP, OP HET MOMENT WORDEN DEZE VALUES NOG NIET NAAR EEN BESTAND GESCHREVEN
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="variableName"></param>
        /// <param name="value"></param>
        internal static void SaveValue<T>(SavePaths path, string variableName, T value)
        {
            if (!saveFileLoaded) LoadFile();
            try
            {
                hashtable.Add(variableName, new QueueValueObject(path, variableName, value));
            }
            catch (ArgumentException e)
            {
                hashtable[variableName] = new QueueValueObject(path, variableName, value);
                Debug.Log(e.ToString());
            }
            WriteTheFile(new List<QueueValueObject>() { hashtable[variableName] });
            Debug.Log(hashtable[variableName]);
        }

        internal static T GetValue<T>(string variableName)
        {
            if (!saveFileLoaded) LoadFile(); Debug.LogWarning("Please do not forget to load a file before calling a value");
            try
            {
                return (T)hashtable[variableName].value;
            }catch
            {
                Debug.LogWarning("This variable does NOT exist");
                return default(T);
            }
        }

        internal static void LoadFile()
        {
            baseSavePath = baseSavePath.Replace("&DataPath&", Application.dataPath);
            //load file stuffjes
            for (int q = 0; q < (int)SavePaths.AmountOfFileTypes; q++)
            {
                jsonstring = ReadAllText(baseSavePath + (q == 0 ? GetPath(SavePaths.Base) : q == 1 ? GetPath(SavePaths.Player) : GetPath(SavePaths.Settings)) + fileExtention);

                try
                {
                    data = JsonMapper.ToObject(jsonstring);
                    continue;
                }
                catch { }

                try
                {

                    for (int i = 0; i < data.Count; i++)
                    {
                        try
                        {
                            QueueValueObject queuevalobj = new QueueValueObject(GetPathEnum(data[i]["specialPath"].ToString()), data[i]["variableName"].ToString(), (object)data[i]["value"]);
                            continue;
                        }
                        catch
                        {
                            Debug.Log("Save value failed to load");
                        }
                        try
                        {
                            QueueValueObject queuevalobj = new QueueValueObject(GetPathEnum(data[i]["specialPath"].ToString()), data[i]["variableName"].ToString(), (object)data[i]["value"]);
                            hashtable.Add(queuevalobj.variableName, queuevalobj);
                        }
                        catch
                        {
                            Debug.Log("Save value already loaded");
                        }
                    }
                }
                catch { }
            }
        }

        public static string GetPath(SavePaths path)
        {
            if (path == SavePaths.Base)
            {
                return "generalSave";
            }
            else if (path == SavePaths.Player)
            {
                return "playerSave";
            }
            else if (path == SavePaths.Settings)
            {
                return "settingsSave";
            }

            return "generalSave";
        }

        public static SavePaths GetPathEnum(string path)
        {
            if (path == "generalSave")
            {
                return SavePaths.Base;
            }
            else if (path == "playerSave")
            {
                return SavePaths.Player;
            }
            else if (path == "settingsSave")
            {
                return SavePaths.Settings;
            }

            return SavePaths.Base;
        }
    }

    public class QueueValueObject
    {
        public string variableName = "";
        public object value;
        public string specialPath = "generalSave";

        public QueueValueObject() { }

        public QueueValueObject(string name, object value)
        {
            this.variableName = name;
            this.value = value;
            this.specialPath = SaveEssentials.GetPath(SavePaths.Base);
        }

        public QueueValueObject(SavePaths path, string name, object value)
        {
            this.variableName = name;
            this.value = value;
            this.specialPath = SaveEssentials.GetPath(path);
        }
    }
}

