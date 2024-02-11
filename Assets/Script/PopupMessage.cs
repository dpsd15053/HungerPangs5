using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupMessage : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public Image messageImage;
    public float displayTime = 2f;

    void Start()
    {
        
        gameObject.SetActive(false);
    }

    public void ShowMessage(string message, Sprite imageSprite = null)
    {
        
        messageText.text = message;

        
        if (messageImage != null)
        {
            messageImage.sprite = imageSprite;
            messageImage.gameObject.SetActive(imageSprite != null);
        }

       
        gameObject.SetActive(true);

        
        Invoke("HideMessage", displayTime);
    }

    public void HideMessage()
    {
       
        gameObject.SetActive(false);
    }
}
