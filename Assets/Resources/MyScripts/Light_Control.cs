using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Control : MonoBehaviour
{
    public Light lightProbe;
    public AnimationCurve colorFunction;

    public void UpdateLightColor(float t)
    {
        float colorValue = colorFunction.Evaluate(t);
        lightProbe.color = new Color(colorValue, colorValue, colorValue);
    }
}
