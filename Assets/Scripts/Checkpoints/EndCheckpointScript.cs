using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCheckpointScript : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private void OnValidate()
    {

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Lv2");
        }
    }
}
