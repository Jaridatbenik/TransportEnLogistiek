using UnityEngine;

public class TaskbarButton_Behaviour : MonoBehaviour
{
    [SerializeField]
    Animator anim = null;
    
    Taskbar_Manager taskbar_Mngr = null;    

    public bool active = false;

    public void PressedButton()
    {        
        taskbar_Mngr.ToggleTab(this, anim);        
        //print(active);
    }


    void Awake()
    {
        taskbar_Mngr = FindObjectOfType<Taskbar_Manager>();    
    }

    //Should be called when exiting the menu from from other ways than the taskbar-button. (like backdrops or back-buttons).
    public void ExternalExit()
    {
        active = false;
    }
}