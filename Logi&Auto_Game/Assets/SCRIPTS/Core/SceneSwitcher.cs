using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    AppHandler appHandler;

    //Apphandler's sceneloader has the transition thing but isn't in all scenes by default.
    //We're checking if we have reference first. It should ALWAYS be in the scene so we can rely on it here.
    public void LoadNewScene(string sceneName)
    {
        if (appHandler == null)
            appHandler = FindObjectOfType<AppHandler>();

        appHandler.LoadNewScene(sceneName);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
    }


    public void ReloadScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        LoadNewScene(sceneName);
    }
}