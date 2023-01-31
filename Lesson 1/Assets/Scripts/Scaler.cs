
using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private float scalingSpeed = 2f;
    [SerializeField] private float targetScaleMin = 1f;
    [SerializeField] private float targetScaleMax = 4f;

    private float currentScale;
    private bool scaleUp = true;

    private void Start()
    {
        currentScale = targetScaleMin;
    }

    private void Update()
    {
        if (scaleUp)
        {
            currentScale = Mathf.Lerp(currentScale, targetScaleMax, scalingSpeed * Time.deltaTime);
            if (currentScale + 0.1f >= targetScaleMax)
            {
                scaleUp = false;
            }
        }
        else
        {
            currentScale = Mathf.Lerp(currentScale, targetScaleMin, scalingSpeed * Time.deltaTime);
            if (currentScale - 0.1f <= targetScaleMin)
            {
                scaleUp = true;
            }
        }

        transform.localScale = new Vector3(currentScale, 1, 1);
    }
}
