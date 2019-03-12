using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EdictChoiceScript : MonoBehaviour
{
    public Toggle[] toggleArray;
    EdictDuurzaamheid ED;
    public bool canChange;

    public void ActiveToggle()
    {
        for (int i = 0; i < toggleArray.Length; i++)
        {
            if (toggleArray[i].isOn == true)
            {
               //monthlyMoney += ED.geld;
               //monthlyDuurzaamheid += ED.duurzaamheid;
               //money --;
               //elke maand kan je veranderen
            }
        }
    }
}
