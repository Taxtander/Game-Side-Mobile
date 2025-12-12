using UnityEngine;

public class Abyss : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            if(other.GetComponent<PlayerHealthManager>() != null)
                other.GetComponent<PlayerHealthManager>().dead();
        
        
    }
}
