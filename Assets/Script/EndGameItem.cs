using UnityEngine;
using static PlayerMovement;

public class EndGameItem : MonoBehaviour
{
    public Canvas endGameCanvas; // Reference to the canvas for the last message
    public float messageDisplayTime = 3f; // Adjust the time as needed

    private bool hasTriggeredEndGame = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasTriggeredEndGame && other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null && !playerController.HasReachedEndGameItem())
            {
                // Activate the canvas for the last message
                if (endGameCanvas != null)
                {
                    endGameCanvas.gameObject.SetActive(true);
                }

                // End the game after a certain time
                Invoke("EndGame", messageDisplayTime);

                // Mark that the player has reached the end-game item
                playerController.SetReachedEndGameItem();

                // Set the flag to avoid triggering multiple times
                hasTriggeredEndGame = true;
            }
        }
    }

    void EndGame()
    {
        // Customize this method based on how you want to end the game
        // For example, load a game over scene, show final scores, etc.
        // In this example, we just quit the application.

        // Deactivate the canvas for the last message
        if (endGameCanvas != null)
        {
            endGameCanvas.gameObject.SetActive(false);
        }

        Debug.Log("Game Completed! Congratulations!");
        Application.Quit();
    }
}
