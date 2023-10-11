using System.Collections;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public Light flickeringLight;
    public float minIntensity = 1.0f;
    public float maxIntensity = 2.0f;
    public float flickerSpeed = 1.5f;

    private float currentIntensity;

    void Start()
    {
        currentIntensity = flickeringLight.intensity;
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            currentIntensity = Random.Range(minIntensity, maxIntensity);
            flickeringLight.intensity = currentIntensity;
            yield return new WaitForSeconds(1 / flickerSpeed);
        }
    }
}
