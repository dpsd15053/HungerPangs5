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
        // Hide the message initially
        gameObject.SetActive(false);
    }

    public void ShowMessage(string message, Sprite imageSprite = null)
    {
        // Set the message text
        messageText.text = message;

        // Set the message image
        if (messageImage != null)
        {
            messageImage.sprite = imageSprite;
            messageImage.gameObject.SetActive(imageSprite != null);
        }

        // Show the message
        gameObject.SetActive(true);

        // Hide the message after a certain time
        Invoke("HideMessage", displayTime);
    }

    public void HideMessage()
    {
        // Hide the message
        gameObject.SetActive(false);
    }
}
