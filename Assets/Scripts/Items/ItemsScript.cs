using System.Collections;
using UnityEngine;

public class ItemsScripts: MonoBehaviour
{

    public GameObject EffectPrefab;
    
    [SerializeField] private AudioClip getItemSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>() != null)
        {

            Instantiate(EffectPrefab, transform.position, Quaternion.identity);

            audioSource.PlayOneShot(getItemSound); 
            Destroy(gameObject, getItemSound.length); 
        }
    }



}
