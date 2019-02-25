using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

public class StatsAnimEvents : MonoBehaviour
{
    public UnityEvent openedLeft = null;
    public UnityEvent openedRight = null;

    public UnityEvent shrunk = null;

    Animator anim = null;
    [SerializeField]Button exitButton;

    void Start()
    {
        anim = GetComponent<Animator>();    
    }


    public void ANIM_OpenedLeft()
    {
        exitButton.onClick.RemoveAllListeners();
        exitButton.onClick.AddListener(openedLeft.Invoke);        
    }
    public void ANIM_OpenedRight()
    {
        exitButton.onClick.RemoveAllListeners();
        exitButton.onClick.AddListener(openedRight.Invoke);        
    }    

    public void ANIM_Shrunk()
    {
        exitButton.onClick.RemoveAllListeners();
        exitButton.onClick.AddListener(shrunk.Invoke);        
    }
}