using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class NewTransition : MonoBehaviour
{
    Animator animator;

    [HideInInspector]
    public string newSceneName = "MainMenu";

    [Header("AnimationNames (use same order)")]
    [SerializeField]
    List<string> tranInNames = new List<string>();
    [SerializeField]
    List<string> tranOutNames = new List<string>();

    int currentTranIndex = 0;

    bool transitioning = false;

    public void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(this);
            return;
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelLoaded;
    }

    void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        animator = GetComponent<Animator>();

        FadeOut();
        //int rndm = Random.Range(0, tranInNames.Count);
        //animator.SetTrigger(tranInNames[rndm]);        
        //Time.timeScale = 0;
    }

    public void FadeOut()
    {
        transitioning = false;

        int rndm = Random.Range(0, tranInNames.Count);
        currentTranIndex = rndm;
        animator.SetTrigger(tranInNames[currentTranIndex]);
    }

    public void FadeToBlack(string s)
    {
        if (!transitioning)
        {
            transitioning = true;

            //Gets called FIRST when a new scene needs to be loaded.            
            newSceneName = s;

            //int rndm = Random.Range(0, tranOutNames.Count);
            animator.SetTrigger(tranOutNames[currentTranIndex]);
            Time.timeScale = 1;
        }
    }

    public void FadingIn()
    {
        //SceneManager.LoadSceneAsync(newSceneName);
        SceneManager.LoadScene(newSceneName);
    }
}