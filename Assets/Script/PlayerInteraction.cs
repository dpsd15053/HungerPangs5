using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public PopupMessage popupMessage;

    private bool isOnTrigger = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Flower"))
        {
            isOnTrigger = true;
            Flower flower = other.GetComponent<Flower>();
            if (flower != null)
            {
                Sprite flowerSprite = flower.tutorialImage;
                string flowerMessage = flower.flowerMessage;

                // Show both the message and the image
                popupMessage.ShowMessage(flowerMessage, flowerSprite);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Flower"))
        {
            isOnTrigger = false;
            // Hide the popup message
            popupMessage.HideMessage();
        }
    }


    public void Update()
    {
        // If you want to continuously show the message as long as the player stays on top
        if (isOnTrigger)
        {
            // You can continuously update the message if needed
            // popupMessage.ShowMessage("Additional Message");
        }
    }
}



