using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

public class StatsAnimEvents : MonoBehaviour
{
    [SerializeField] UnityEvent openedLeft = null;
    [SerializeField] UnityEvent openedRight = null;
    [SerializeField] UnityEvent openedCenter = null;

    [SerializeField]TaskbarButton_Behaviour taskbar_behaviour = null;

    public UnityEvent shrunk = null;

    Animator anim = null;
    [SerializeField]Button exitButton = null;

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

    public void ANIM_OpenedCenter()
    {
        exitButton.onClick.RemoveAllListeners();
        exitButton.onClick.AddListener(openedCenter.Invoke);
    }

    public void ANIM_Shrunk()
    {
        exitButton.onClick.RemoveAllListeners();
        exitButton.onClick.AddListener(shrunk.Invoke);        
    }




    public void CloseWithExitButton()
    {
        taskbar_behaviour.active = false;
    }
}