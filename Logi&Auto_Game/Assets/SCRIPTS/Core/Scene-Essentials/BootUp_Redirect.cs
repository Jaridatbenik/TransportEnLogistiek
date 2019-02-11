using UnityEngine.SceneManagement;
using UnityEngine;

public class BootUp_Redirect : MonoBehaviour
{
    AppHandler apphandler;
    string currentSceneName = "";    

    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;

        if(FindObjectOfType<AppHandler>() == null)
        {
            AppHandler.loadAfterBootUp = currentSceneName;
            SceneManager.LoadScene(0);
        }

        Destroy(this);
    }
}