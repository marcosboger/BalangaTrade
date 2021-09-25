using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathNet.Numerics.Distributions;

public class Papers : MonoBehaviour
{
    Normal inicial;
    [SerializeField]
    string nome;
    [SerializeField]
    float Media;
    [SerializeField]
    float Desvio;

    // Start is called before the first frame update
    void Start()
    {
        inicial = Normal.WithMeanVariance(Media, (Desvio*Desvio));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0.005f, 0, 0));
        var sample = inicial.Sample();
        Debug.Log(sample);
        if (sample > Media)
            transform.Translate(new Vector3(0, 0.01f, 0));
        else
            transform.Translate(new Vector3(0, -0.01f, 0));
    }
}
