using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    // Start is called before the first frame update
    public int money;
    public int unitsLeft;
    public GameObject unit;

    public void OnButtonPress() {
        if (money >= 200 && unitsLeft > 0) {
            money -= 200;
            unitsLeft--;
            GameObject newUnit = Instantiate(unit);
            newUnit.transform.position = new Vector3(0, 0, 0);

        }

    }

}
