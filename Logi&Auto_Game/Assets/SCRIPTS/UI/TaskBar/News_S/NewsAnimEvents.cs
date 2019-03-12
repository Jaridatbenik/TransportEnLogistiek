using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class NewsAnimEvents : MonoBehaviour
{
    [SerializeField]
    Transform contentParent = null;

    [SerializeField]    
    Transform mailContentPrefab = null;

    [Space]
    //-------------    
    public TextMeshProUGUI titleText = null;    
    public TextMeshProUGUI volumeText = null;
    //-------------

    string title = null;
    string volume = null;

    void Start()
    {
        //SpawnNewContent("Title", "volume");    
    }

    public void SpawnNewContent(string title, string volume)
    {
        MailButton mailButton = Instantiate(mailContentPrefab, contentParent).GetComponent<MailButton>();
        TextMeshProUGUI text = mailButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        mailButton.newsAnimEvents = this;

        text.text = title;

        mailButton.titleText = title;
        mailButton.volumeText = volume;

        Button button = mailButton.GetComponent<Button>();        
    }

    //public void SetPreviewText()
    //{        
    //    titleText.text = title;
    //    volumeText.text = volume;
    //}
}