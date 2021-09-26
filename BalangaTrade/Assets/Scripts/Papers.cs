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
    float mean;
    [SerializeField]
    float std;
    float price;
    float percentageVariation;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(changePaperPrice(1));
        inicial = Normal.WithMeanVariance(mean, (std*std));
        price = mean;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector3(0.005f, 0, 0));
    }
    public float getPrice()
    {
        return price;
    }

    public float getPercentageVariation()
    {
        return percentageVariation;
    }

    IEnumerator changePaperPrice(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);

            // Code to execute after the delay
            var sample = inicial.Sample();
            price = (float)sample;
            percentageVariation = ((price / mean) - 1) * 100;
            //Debug.Log(sample);
            if (sample > mean)
                transform.Translate(new Vector3(0, 0.01f, 0));
            else
                transform.Translate(new Vector3(0, -0.01f, 0));
        }
    }
}
