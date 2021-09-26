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
    Dictionary<string, int> papers;
    Text myMoney;
    Text walletValue;

    // Start is called before the first frame update
    void Start()
    {
        myMoney = this.GetComponent<Text>();
        walletValue = GameObject.Find("Valor Carteira").GetComponent<Text>();
        papers = new Dictionary<string, int>();
        myMoney.text = money.ToString("F2");
        walletValue.text = "Valor Carteira: 0";
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(money);
        myMoney.text = "Dinheiro: " + money.ToString("F2");
        walletValue.text = "Valor Carteira: " + calculateWalletValue().ToString("F2");
        Debug.Log(calculateWalletValue());
    }

    public void buyPaper()
    {
        string name = GameObject.Find("Label").GetComponent<Text>().text;
        int quantity = int.Parse(GameObject.Find("Texto Quantidade").GetComponent<Text>().text);
        double price = GameObject.Find(name).GetComponent<Papers>().getPrice();

        if (price * quantity > money)
            return; 

        money -= price * quantity;
        if (papers.ContainsKey(name))
            papers[name] = quantity + papers[name];
        else
            papers.Add(name, quantity);

        foreach (KeyValuePair<string, int> kvp in papers)
        {
            Debug.LogFormat("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
        }
    }
    
    public void sellPaper(string name, double price)
    {
        int quantity;
        papers.TryGetValue(name, out quantity);
        money += quantity * price;
        papers.Remove(name);
    }

    private double calculateWalletValue()
    {
        double value = 0;
        foreach (KeyValuePair<string, int> kvp in papers)
        {
            value += GameObject.Find(kvp.Key).GetComponent<Papers>().getPrice() * kvp.Value;
        }
        return value;
    }
}
