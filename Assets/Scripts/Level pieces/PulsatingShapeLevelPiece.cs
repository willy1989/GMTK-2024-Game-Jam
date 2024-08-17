using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsatingShapeLevelPiece : MonoBehaviour
{
    private float elapsedTime = 0;

    [SerializeField] private float cycleDuration = 2f;

    private Vector3 startScale;

    [SerializeField] private Vector3 endScale;

    private void Awake()
    {
        startScale = transform.localScale;
    }

    private void Update()
    {
        ChangeScale();
    }

    private void ChangeScale()
    {
        elapsedTime += Time.deltaTime;

        float t = interpolationTValue(elapsedTime, cycleDuration);

        t = SineWaveFunction(t);

        Vector3 newScale = Vector3.Lerp(startScale, endScale, t);

        transform.localScale = newScale;
    }

    float SineWaveFunction(float t)
    {
        return Mathf.Sin(t * Mathf.PI);
    }

    private float interpolationTValue(float startValue, float endValue)
    {
        float result = startValue / endValue;

        result = result % 1f;

        return result;
    }
}
