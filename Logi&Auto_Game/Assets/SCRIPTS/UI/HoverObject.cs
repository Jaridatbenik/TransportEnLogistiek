using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverObject : MonoBehaviour
{
    public RectTransform message;
    [HideInInspector]
    public RectTransform messageImage;

    void Awake()
    {
        message.gameObject.SetActive(false);
        messageImage = message.GetChild(0).GetComponent<RectTransform>();
    }
}