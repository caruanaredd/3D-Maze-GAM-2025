using TMPro;
using UnityEngine;

public class PlayerCollection : MonoBehaviour
{
    // Add a scoring system here (HW)
    private int score = 0;
    public TMP_Text scoreText;
    
    private void OnTriggerEnter(Collider other)
    {
        // Only destroy if collectable
        if (other.CompareTag("Collectable"))
        {
            AddScore(1);
            Destroy(other.gameObject);
        }
    }

    private void AddScore(int points)
    {
        score = score + points;
        scoreText.text = $"<b>Score:</b> {score}";
    }
}
