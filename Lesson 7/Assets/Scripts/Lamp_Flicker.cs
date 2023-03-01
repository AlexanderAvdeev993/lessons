
using UnityEngine;

public class Lamp_Flicker : MonoBehaviour
{   
	public float constantIntens = 1.0f;
    public float flickerTimeMin = 0.2f;
    public float flickerTimeMax = 0.6f;
    public float flickerIntensityMin = 0.2f;
    public float flickerIntensityMax = 4.0f;

    private float timeDown;

    private void Start()
    {
        timeDown = 1.0f;
        gameObject.GetComponent<Light>().intensity = constantIntens;
    }

    private void Update()
    {
        if (timeDown > 0)
        {
            timeDown -= Time.deltaTime;
        }

        if (timeDown <= 0)
        {
            float intensity = Random.Range(flickerIntensityMin, flickerIntensityMax);
            gameObject.GetComponent<Light>().intensity = intensity;
            timeDown = Random.Range(flickerTimeMin, flickerTimeMax);
        }
    }
}
