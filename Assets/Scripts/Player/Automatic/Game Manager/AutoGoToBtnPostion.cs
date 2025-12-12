using Player.Automatic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AutoGoToBtnPostion : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private GameObject button;
    [SerializeField] private float btnPos;
    
    [Header("Player")]
    [SerializeField] private GameObject player;
    private AutomaticPlayerVariabls playerAutoRun;

    [SerializeField] private float stopDistance = 2f;

    private bool isMoving = false;

    void Start()
    {
        btnPos = button.transform.position.x;
        playerAutoRun = player.GetComponent<AutomaticPlayerVariabls>();
    }

    public void OnClick()
    {
        isMoving = true;
    }

    void Update()
    {
        if (!isMoving) return;

        float playerPos = player.transform.position.x; 
        float distance = Mathf.Abs(playerPos - btnPos);

        if (btnPos < playerPos)
            playerAutoRun.FaceRight = false;
        else if (btnPos > playerPos)
            playerAutoRun.FaceRight = true;

        if (distance <= stopDistance)
        {
            isMoving = false;
            playerAutoRun.Speed = 0;
            StartCoroutine(WaitAndLoad(1.5f));
        }
        
        
    }

    private IEnumerator WaitAndLoad(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("Scenes/Starter Levels/Levels/Lv1");
    }
}