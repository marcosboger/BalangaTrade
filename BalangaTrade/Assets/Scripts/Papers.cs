using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathNet.Numerics.Distributions;

public class Papers : MonoBehaviour
{
    Normal normal;

    // Start is called before the first frame update
    void Start()
    {
        normal = Normal.WithMeanVariance(3.0, 1.5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0.01f, 0, 0));
        var sample = normal.Sample();
        Debug.Log(sample);
        if (sample > 3.0)
            transform.Translate(new Vector3(0, 0.1f, 0));
        else
            transform.Translate(new Vector3(0, -0.1f, 0));
    }
}
