using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EdictChoiceScript : MonoBehaviour
{
    public Toggle[] toggleArray;

    public void ActiveToggle()
    {
        for (int i = 0; i < toggleArray.Length; i++)
        {
            if (toggleArray[i].isOn == true)
            {

            }
        }
    }
}
