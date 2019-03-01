using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Taskbar_Manager : MonoBehaviour
{   
    List<TaskbarButton_Behaviour> tabWindows = new List<TaskbarButton_Behaviour>();
    List<Animator> tabAnims = new List<Animator>();

    void Awake()
    {
        Transform gridParent = transform.GetChild(0);
        for(int i = 0; i < gridParent.childCount; i++)
        {
            tabWindows.Add(gridParent.GetChild(0).GetComponent<TaskbarButton_Behaviour>());
        }
    }

    public void ToggleTab(TaskbarButton_Behaviour button, Animator anim)
    {
        for (int i = 0; i < tabWindows.Count; i++)
        {                        
            if(tabWindows[i].active)
            {
                tabAnims[i].SetTrigger("Exit");
                tabWindows[i].active = false;   
            }
            else if(!tabWindows[i].active)
            {
                
            }
        }
        
        if(!button.active)
        {
            anim.SetTrigger("Enter");
            button.active = true;
        }    
        else if(button.active)
        {
            anim.SetTrigger("Exit");
            button.active = false;
        }    
    }
}