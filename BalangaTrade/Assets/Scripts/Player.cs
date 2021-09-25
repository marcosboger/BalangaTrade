using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    string nickname;
    [SerializeField]
    double money;
    Dictionary<string, double> papers;

    // Start is called before the first frame update
    void Start()
    {
        papers = new Dictionary<string, double>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buyPaper()
    {
        string name = GameObject.Find("Label").GetComponent<Text>().text;
        int quantity = int.Parse(GameObject.Find("Texto Quantidade").GetComponent<Text>().text);
        double price = GameObject.Find(name).GetComponent<Papers>().getPrice(); 
        
        money -= price * quantity;
        // papers.Add(name, quantity);
        Debug.Log(name);
        Debug.Log(quantity);
        Debug.Log(price);
    }
    
    public void sellPaper(string name, double price)
    {
        double quantity;
        papers.TryGetValue(name, out quantity);
        money += quantity * price;
        papers.Remove(name);
    }
}
