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
        //active = !active;
        print(active);
    }


    void Awake()
    {
        taskbar_Mngr = FindObjectOfType<Taskbar_Manager>();    
    }
}