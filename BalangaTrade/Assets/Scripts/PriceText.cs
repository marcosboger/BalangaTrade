using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PriceText : MonoBehaviour
{
    Text price;
    [SerializeField]
    string paper;

    // Start is called before the first frame update
    void Start()
    {
        price = this.GetComponent<Text>();
        price.text = GameObject.Find(paper).GetComponent<Papers>().getPrice().ToString("F2") + " (" + GameObject.Find(paper).GetComponent<Papers>().getPercentageVariation().ToString("F2") + "%)";
    }

    // Update is called once per frame
    void Update()
    {
        price.text = GameObject.Find(paper).GetComponent<Papers>().getPrice().ToString("F2") + " (" + GameObject.Find(paper).GetComponent<Papers>().getPercentageVariation().ToString("F2") + "%)";
    }
}
