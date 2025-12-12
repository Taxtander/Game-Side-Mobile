using UnityEngine;

public class MobilePerformanceOptimizer : MonoBehaviour
{
    [Header("Target FPS Settings")]
    [SerializeField] private int targetFrameRate = 60;
    [SerializeField] private bool vSyncEnabled = false;
    
    [Header("Quality Settings")]
    [SerializeField] private bool optimizeForMobile = true;
    
    [Header("Physics Settings")]
    [SerializeField] private float fixedTimeStep = 0.02f;
    
    private void Awake()
    {
        ApplyOptimizations();
    }

    private void ApplyOptimizations()
    {
        Application.targetFrameRate = targetFrameRate;
        
        QualitySettings.vSyncCount = vSyncEnabled ? 1 : 0;
        
        if (optimizeForMobile)
        {
            QualitySettings.pixelLightCount = 1;
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
            QualitySettings.antiAliasing = 0;
            QualitySettings.softParticles = false;
            QualitySettings.realtimeReflectionProbes = false;
            
            Time.fixedDeltaTime = fixedTimeStep;
            
            Physics2D.simulationMode = SimulationMode2D.FixedUpdate;
            Physics2D.reuseCollisionCallbacks = true;
        }
        
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void OnValidate()
    {
        if (Application.isPlaying)
        {
            ApplyOptimizations();
        }
    }
}
