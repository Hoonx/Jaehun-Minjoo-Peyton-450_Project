using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    // Start is called before the first frame update
    public int money;
    public GameObject unit;
    public Text moneyText;

    public void Start()
    {
        UpdateMoneyDisplay();
    }
    public void OnButtonPress() {
        if (money >= 200) {
            money -= 200;
            UpdateMoneyDisplay();
            GameObject newUnit = Instantiate(unit);
            newUnit.transform.position = new Vector3(0, 0, 0);

        }

    }
    private void UpdateMoneyDisplay()
    {
        moneyText.text = "Money: " + money.ToString();
    }

}
