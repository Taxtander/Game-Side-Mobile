using System;
using System.Collections;
using UnityEngine;

public class CameraVectorChangerScript : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] private Camera camera;
    [SerializeField] private Vector3 target = new Vector3(0,-0.5f,-10);
    [SerializeField] private bool returnToMainLocation = false;
    [SerializeField] private float returnDelay = 0.2f;

    private SmoothCameraFollow cameraFollow;

    private void Awake()
    {
        if (camera != null)
        {
            cameraFollow = camera.GetComponent<SmoothCameraFollow>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (cameraFollow == null)
            return;

        Vector3 lastOffset = cameraFollow.Offset;
        cameraFollow.Offset = target;

        if (returnToMainLocation)
        {
            StartCoroutine(ReturnToMainLocation(lastOffset));
        }
        else
        {
            gameObject.SetActive(false);

        }
    }

    private IEnumerator ReturnToMainLocation(Vector3 originalOffset)
    {
        yield return new WaitForSeconds(returnDelay);
        
        if (cameraFollow != null)
        {
            cameraFollow.Offset = originalOffset;
            gameObject.SetActive(false);

        }
    }
}