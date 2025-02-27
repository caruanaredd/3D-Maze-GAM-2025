using UnityEngine;

public class PlayerCollection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Only destroy if collectable
        if (other.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
        }
    }
}
