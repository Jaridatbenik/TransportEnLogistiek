using UnityEngine.SceneManagement;
using UnityEngine;

public class AppHandler : MonoBehaviour
{
    NewTransition transition;
    //If you want to go to menu and back, change this and load bootUpMenu (scene0)
    public static string loadAfterBootUp = "MainMenu";

    //DownhillEvent e;

    void Start()
    {
        //e = FindObjectOfType<DownhillEvent>();
        //e.SetGameState(GameState.InStartup);
        //e.SubscribeToEvent(EventTypeEnum.onStartup, OnStartup);

        if (loadAfterBootUp == "BootUpScene")
        {
            loadAfterBootUp = "MainMenu";
        }

        DontDestroyOnLoad(gameObject);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(this);
            return;
        }


        transition = FindObjectOfType<NewTransition>();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            LoadNewScene(loadAfterBootUp);
        }

    }

    void OnStartup()
    {
        //e.SetGameState(GameState.InMenu);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            LoadNewScene("MainMenu");
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            LoadNewScene("Sep-TScene2");
        }
    }

    public void LoadNewScene(string sceneName)
    {        
        transition.FadeToBlack(sceneName);
    }
}