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

               
                popupMessage.ShowMessage(flowerMessage, flowerSprite);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Flower"))
        {
            isOnTrigger = false;
            
            popupMessage.HideMessage();
        }
    }


    public void Update()
    {
       
        if (isOnTrigger)
        {
           
        }
    }
}



