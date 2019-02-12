using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine;

public class HoverButton : MonoBehaviour
    , IPointerEnterHandler
    , IPointerExitHandler
    , IPointerDownHandler
    , IPointerUpHandler
{
    Image img;
    Color baseColor;
    
    [SerializeField]
    RectTransform hoverMessage;
    RectTransform hoverMessageImage;    

    [SerializeField]
    float hoverDarken = 0.9f;
    [SerializeField]
    float pressDarken = 0.75f;

    bool hovering = false;

    [SerializeField]
    UnityEvent onClick;

    void Awake()
    {
        img = GetComponent<Image>();
        baseColor = img.color;
        hoverMessageImage = hoverMessage.GetChild(0).GetComponent<RectTransform>();
        hoverMessage.gameObject.SetActive(false);    
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovering = true;
        ApplyColorMultiplier(hoverDarken);
        hoverMessage.gameObject.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        hovering = false;
        img.color = baseColor;
        hoverMessage.gameObject.SetActive(false);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        ApplyColorMultiplier(pressDarken);        
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        ApplyColorMultiplier(hoverDarken);
        hoverMessage.gameObject.SetActive(false);
    }

    void Update()
    {
        if(hovering)
        {
            Vector3 newPos = hoverMessageImage.anchoredPosition;
            if (Input.mousePosition.x > Screen.width * 0.75f)
            {                
                newPos.x = -Mathf.Abs(newPos.x);                
            }
            else if(Input.mousePosition.x < Screen.width * 0.75f)
            {
                newPos.x = Mathf.Abs(newPos.x);                
            }

            hoverMessageImage.anchoredPosition = newPos;
            hoverMessage.position = Input.mousePosition;

            if (Input.GetMouseButtonUp(0))
            {
                onClick.Invoke();
            }            
        }    
    }

    void ApplyColorMultiplier(float multiplier)
    {
        Color clr = baseColor;
        clr *= multiplier;
        img.color = clr;
    }
}