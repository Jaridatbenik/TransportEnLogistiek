using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailButton : MonoBehaviour
{
    public string titleText = "";
    public string volumeText = "";

    [HideInInspector]
    public NewsAnimEvents newsAnimEvents = null;    

    public void MailButtonPressed()
    {
        newsAnimEvents.titleText.text = titleText;
        newsAnimEvents.volumeText.text = volumeText;
        //newsAnimEvents.SetPreviewText();
    }
}