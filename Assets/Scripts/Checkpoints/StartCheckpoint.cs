using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCheckpoint : MonoBehaviour
{
    
    [Header("Checkpoint Settings")]
    [SerializeField] private GameObject player;
    
    void Start()
    {
        player.transform.position = gameObject.transform.position;
    }

    private void Update()
    {
        if (player == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);            
        }
    }
}
