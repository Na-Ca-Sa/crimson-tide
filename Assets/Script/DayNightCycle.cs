using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayNightCycle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static bool isNight;
    public Light2D globalLight;
    public float DayTime = 2f;
    public AnimationCurve globalIntensity;
    float t;

    // Update is called once per frame
    void Update()
    {
        t = (t + Time.deltaTime / DayTime) % 1f;
        float g=globalIntensity.Evaluate(t);
        globalLight.intensity = g;
        isNight = g < 0.6f;
    }
}
