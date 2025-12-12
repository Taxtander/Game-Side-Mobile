using UnityEngine;

public class PalyerHealthUIGameManager : MonoBehaviour
{
    private GameObject Player;
    private PlayerHealthManager playerHealthManager;

    [Header("Player Health")]
    [SerializeField] private int Healthes;
    [SerializeField] private GameObject[] HealthUI;
    
    [Header("Prefab")]
    [SerializeField] private GameObject DieEffect;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        
        if (Player != null)
        {
            playerHealthManager = Player.GetComponent<PlayerHealthManager>();
        }
        else
        {
            Debug.LogError("eroor");
        }
    }

    void Update()
    {
        if (Player == null || playerHealthManager == null)
        {
            return;
        }

        Healthes = playerHealthManager.Health;

        if (Healthes > 0)
        {
            for (int i = 0; i < HealthUI.Length; i++)
            {
                HealthUI[i].SetActive(i < Healthes);
            }
        }

    }
    
    
}
