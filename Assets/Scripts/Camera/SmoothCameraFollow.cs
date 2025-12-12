using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Vector3 Offset
    {
        get => offset;
        set => offset = value;
    }
    [Header("Target Settings")]
    [SerializeField] private Transform target;
    
    [Header("Smooth Settings")]
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset = new Vector3(0f, 2f, -10f);



    [Header("Camera Bounds (Optional)")]
    [SerializeField] private bool useBounds = false;
    [SerializeField] private float minX = -50f;
    [SerializeField] private float maxX = 50f;
    [SerializeField] private float minY = -50f;
    [SerializeField] private float maxY = 50f;
    
    [Header("Look Ahead")]
    [SerializeField] private bool useLookAhead = false;
    [SerializeField] private float lookAheadDistance = 2f;
    [SerializeField] private float lookAheadSpeed = 2f;
    
    private float currentLookAheadX;
    private PlayerMovement playerMovement;

    private void Start()
    {
        if (target != null)
        {
            playerMovement = target.GetComponent<PlayerMovement>();
        }
    }

    private void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 desiredPosition = target.position + offset;

        if (useLookAhead && playerMovement != null)
        {
            float targetLookAheadX = playerMovement.GetFacingRight() ? lookAheadDistance : -lookAheadDistance;
            currentLookAheadX = Mathf.Lerp(currentLookAheadX, targetLookAheadX, lookAheadSpeed * Time.deltaTime);
            desiredPosition.x += currentLookAheadX;
        }

        if (useBounds)
        {
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);
        }

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        if (newTarget != null)
        {
            playerMovement = newTarget.GetComponent<PlayerMovement>();
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (!useBounds)
            return;

        Gizmos.color = Color.yellow;
        
        Vector3 topLeft = new Vector3(minX, maxY, 0);
        Vector3 topRight = new Vector3(maxX, maxY, 0);
        Vector3 bottomLeft = new Vector3(minX, minY, 0);
        Vector3 bottomRight = new Vector3(maxX, minY, 0);

        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);
    }
}
