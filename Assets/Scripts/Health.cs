using UnityEngine;

public class Health : MonoBehaviour
{
    public int points = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trap"))
        {
            Damage(1);
        }
    }

    // To remove some health points
    private void Damage(int value)
    {
        points = points - value;
        if (points < 1)
        {
            // HW:
            // DO NOT DESTROY
            // Move the player to the start
            // Reset points to 5
            
            Destroy(gameObject);
        }
    }
}
