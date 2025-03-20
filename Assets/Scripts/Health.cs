using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public int points = 5;
    public Vector3 respawnPosition;
    public TMP_Text healthText;
    public EndScreenAnimation gameOverScreen;

    private void Start()
    {
        respawnPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trap"))
        {
            Damage(1);
        }

        if (other.CompareTag("Fireball"))
        {
            Damage(2);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Checkpoint"))
        {
            // we can set the position based on the
            // checkpoint so that this acts as a 
            // guaranteed safe spot
            respawnPosition = other.transform.position;
            respawnPosition.y = transform.position.y;
        }
    }

    // To remove some health points
    private void Damage(int value)
    {
        points = points - value;
        healthText.text = $"<b>Health:</b>" +
                          $" {points}";
        
        // HW:
        // Move the player to the start
        transform.position = respawnPosition;

        // Reset points to 5
        // points = 5;
        
        if (points < 1)
        {
            gameOverScreen.StartFade();
            Destroy(gameObject);
        }
    }
}
