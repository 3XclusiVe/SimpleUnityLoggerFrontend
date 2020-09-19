using UnityEngine;

public class LoggerExample : MonoBehaviour
{
    void Awake()
    {
        CustomLog.LogWarning("Warning");
    }

    void Start()
    {
        CustomLog.Log("Info");
        CustomLog.LogDebug("Debug");
    }

    void OnEnable()
    {
        CustomLog.LogError("Error");
    }

    void Update()
    {
        //add UNITY_LOG_DEBUG to not to strip calling LogDebug in all project
        CustomLog.LogDebug($"{typeof(LoggerExample)} some heavy string interpolation {HeavyMethod()}");
    }

    string HeavyMethod()
    {
        return "@@ heavy string from heavy method @@";
    }
}