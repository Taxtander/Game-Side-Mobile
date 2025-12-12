using UnityEngine;

public class GameOverManagement : MonoBehaviour
{
    public GameObject Player;
    public GameObject EndItem;
    
    private int Health;
    
    [Header("UI")]
    [SerializeField] private GameObject LoseUI;
    [SerializeField] private GameObject WinUI;
    
    [Header("Sound")]
    [SerializeField] private AudioClip WinAudio;
    [SerializeField] private AudioClip LoseAudio;
    [SerializeField] private GameObject BackGroundAudio;
    
    
    
    
    
    
    
    
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        
        EndItem = GameObject.FindGameObjectWithTag("EndItem");
    }

    void Update()
    {
        Health = Player.GetComponent<PlayerHealthManager>().Health;

        if (EndItem == null)
        {
            WinUI.SetActive(true);
        }
        else if (Health == 0)
        {
            LoseUI.SetActive(true);
        }
        
    }
}
