using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverMessageHandler : MonoBehaviour
{
    RectTransform hoverMessage;
    RectTransform hoverMessageImage;
        
    Camera cam;

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        HoverObject ho = null;
        if (hit.transform != null)
            ho = hit.transform.GetComponent<HoverObject>();                    

        if (ho != null)
        {
            hoverMessage = ho.message;
            hoverMessageImage = ho.messageImage;          
            hoverMessage.gameObject.SetActive(true);
        }
        else
        {
            if (hoverMessage != null)
            {
                hoverMessage.gameObject.SetActive(false);
                hoverMessageImage = null;
                hoverMessage = null;
            } 

        }


        if(hoverMessageImage)
        {            
            Vector3 newPos = hoverMessageImage.anchoredPosition;

            //X
            if (Input.mousePosition.x > Screen.width * 0.75f)
            {
                newPos.x = -Mathf.Abs(newPos.x);
            }
            else if (Input.mousePosition.x < Screen.width * 0.25f)
            {
                newPos.x = Mathf.Abs(newPos.x);
            }
            //Y
            if(Input.mousePosition.y > Screen.height * 0.75f)
            {             
                newPos.y = -Mathf.Abs(newPos.y);
            }
            else if(Input.mousePosition.y < Screen.height * 0.25f)
            {                
                newPos.y = Mathf.Abs(newPos.y);
            }

            hoverMessageImage.anchoredPosition = newPos;
            hoverMessage.position = Input.mousePosition;
        }        



        if (hoverMessage != null)
        {
            hoverMessage.position = Input.mousePosition;
        }
    }

    void Start()
    {
        cam = Camera.main;
    }
}