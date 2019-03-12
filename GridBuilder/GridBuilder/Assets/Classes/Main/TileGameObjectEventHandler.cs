using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TileGameObjectEventHandler : MonoBehaviour
{
    TileGameObject tileGameObject;

    public UnityEvent updateEvent = new UnityEvent();
    public UnityEvent fixedUpdateEvent = new UnityEvent();

    void Start()
    {
        tileGameObject = gameObject.GetComponent<TileGameObject>();
    }

    public void TileUpdate()
    {
        updateEvent.Invoke();
    }

    public void TileFixedUpdate()
    {
        fixedUpdateEvent.Invoke();
    }

    
}
