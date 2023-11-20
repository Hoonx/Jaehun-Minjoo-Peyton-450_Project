using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public static BuyButton instance;
    // Start is called before the first frame update
    public int money;
    public GameObject[] unit;
    public Text moneyText;
    //public PlatformController coffin;
    public Vector3 position;


    void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        UpdateMoneyDisplay();
        //coffin = GetComponent<PlatformController>();
        
    }


    public void OnButtonPress() {
        if (money >= 200) {
            money -= 200;
            UpdateMoneyDisplay();
            int randomSpawn = Random.Range(0, unit.Length);
            
            GameObject newUnit = Instantiate(unit[randomSpawn]);
            newUnit.transform.position = position;

        }

    }

    public void UpdateMoneyDisplay()
    {
        moneyText.text =  money.ToString();
    }

    public void AddMoney(int amount)
    {
        money += amount;
        UpdateMoneyDisplay();
        Debug.Log("Total Money now: " + money);
    }


}

