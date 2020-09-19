using UnityEngine;

public class LoggerExample : MonoBehaviour
{
    //remove UNITY_NOT_RELEASE define in Project setting to completely strip all logs
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
        CustomLog.LogError("Heavy method called!");
        return "@@ heavy string from heavy method @@";
    }
}