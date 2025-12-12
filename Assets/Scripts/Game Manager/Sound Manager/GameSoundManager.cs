using System;
using UnityEngine;

public class GameSoundManager : MonoBehaviour
{
    
    
    private AudioSource managerAudio;
    
    private PlayerVariables pv;
    private ItemsScripts itemScripts;
    
    [Header("Audio")]
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip dieSound;

    private GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        pv = Player.GetComponent<PlayerVariables>();
        
        itemScripts = GameObject.FindGameObjectWithTag("Items").GetComponent<ItemsScripts>();
        
        
        
        managerAudio = gameObject.GetComponent<AudioSource>();
        
        
    }

    private void Update()
    {
        if (pv.IsDead)
            PlaySound(dieSound);
        else if (pv.IsHit)
            PlaySound(hitSound);
        else if (pv.IsJumping)
            PlaySound(jumpSound);
        


        
    }

    private void PlaySound(AudioClip sound)
    {
        managerAudio.PlayOneShot(sound);
    }
}
