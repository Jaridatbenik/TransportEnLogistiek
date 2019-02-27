using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{

    public Item showThisItem;
    SpriteRenderer spriteRenderer;
    Sprite itemSprite;
    int currentID = -1;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        if(showThisItem != null && showThisItem.itemID != currentID)
        {
            currentID = showThisItem.itemID;
            spriteRenderer.sprite = ItemSprites.availableItemSprites[currentID];
            transform.position = new Vector3((float)((int)Random.Range(0, 40)) +0.5f, (float)((int)Random.Range(0, 40)) + 0.5f, -1);
        }
    }
}
