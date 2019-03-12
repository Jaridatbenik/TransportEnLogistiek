using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SavingDownhillDeep;

namespace Downhill
{
    namespace SaveHandler
    {
        public class SaveHandler : MonoBehaviour
        {
            /// <summary>
            /// Call this method to instantly save a variable in the main save file
            /// </summary>
            /// <typeparam name="T">The type of the variable you want to save</typeparam>
            /// <param name="variableName">The name of the variable you want to save</param>
            /// <param name="value">The value you want to save</param>
            internal static void SaveVariable<T>(string variableName, T value)
            {
                SaveEssentials.SaveValue<T>(variableName, value);
            }

            /// <summary>
            /// Call this method to instantly save a variable in the specified save file
            /// </summary>
            /// <typeparam name="T">The type of the variable you want to save</typeparam>
            /// <param name="path">The path of the file you want to save the variable to</param>
            /// <param name="variableName">The name of the variable you want to save</param>
            /// <param name="value">The value you want to save</param>
            internal static void SaveVariable<T>(string variableName, T value, SavePaths path)
            {
                SaveEssentials.SaveValue<T>(path, variableName, value);
            }

            /// <summary>
            /// Queue a variable here in order to save it with the SaveQueue command
            /// </summary>
            /// <typeparam name="T">The type of the variable you want to save</typeparam>
            /// <param name="variableName">The name of the variable you want to save in the queue</param>
            /// <param name="value">The value you want to savein the queue</param>
            internal static void QueueVariable<T>(string variableName, T value)
            {
                SaveEssentials.QueueSaveValue<T>(variableName, value);
            }

            /// <summary>
            /// Queue a variable here in order to save it with the SaveQueue command
            /// </summary>
            /// <typeparam name="T">The type of the variable you want to save</typeparam>
            /// <param name="path">The path of the file you want to save the variable to</param>
            /// <param name="variableName">The name of the variable you want to save in the queue</param>
            /// <param name="value">The value you want to save in the queue</param>
            internal static void QueueVariable<T>(string variableName, T value, SavePaths path)
            {
                SaveEssentials.QueueSaveValue<T>(path, variableName, value);
            }

            /// <summary>
            /// Clears all the variables in the Queue, this method should never be called but its there
            /// </summary>
            internal static void PoofQueue()
            {
                SaveEssentials.PoofQueue();
            }

            /// <summary>
            /// Run this method in order to save all the stored variables in the Queue. Warning: this may cause a lag spike
            /// </summary>
            internal static void SaveQueue()
            {
                SaveEssentials.SaveQueue();
            }

            /// <summary>
            /// Run this at the beginning of the game to load all the stored save data.
            /// </summary>
            [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
            internal static void LoadSaveData()
            {
                SaveEssentials.LoadFile();
            }

            /// <summary>
            /// Get value of the variable you specify
            /// </summary>
            /// <typeparam name="T">The type of the variable you want to read</typeparam>
            /// <param name="variableName">The name of the variable you stored</param>
            /// <returns>The value of the saved variable</returns>
            internal static T GetValue<T>(string variableName)
            {
                return SaveEssentials.GetValue<T>(variableName);
            }
        }
    }
}
