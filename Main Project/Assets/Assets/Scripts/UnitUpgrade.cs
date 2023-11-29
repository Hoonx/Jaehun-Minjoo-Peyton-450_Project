using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitUpgrade : MonoBehaviour
{
    public GameObject upgradeButtonPrefab; // Reference to the upgrade button prefab
    private GameObject upgradeButtonInstance; // Instance of the button
    private static UnitUpgrade selectedUnit; // Currently selected unit

    private bool allowButtonReactivation = true;

    private Button closeButton;
    public int upgradeCost =100;

    private TMP_Text upgradeMoney;
    public Vector3 offset;

    //private bool isMouseOver = false;


    void Start()
    {
        upgradeButtonInstance = Instantiate(upgradeButtonPrefab, FindObjectOfType<Canvas>().transform);
        Button upgradeButton2 = upgradeButtonInstance.GetComponent<Button>();
        upgradeButton2.onClick.AddListener(Upgrade);

        closeButton = upgradeButtonInstance.transform.Find("CloseButton").GetComponent<Button>();
        closeButton.onClick.AddListener(CloseUpgrade);

        upgradeMoney = upgradeButtonInstance.transform.Find("UpgradeText").GetComponent<TMP_Text>();

        upgradeButtonInstance.SetActive(false);
        selectedUnit = null;
    }


    void Update()
    {
        // Update the position of the button if it's active and there's a selected unit
        if (selectedUnit != null && upgradeButtonInstance != null)
        {
            if (upgradeButtonInstance.activeSelf)
            {
                Vector3 screenPosition = selectedUnit.transform.position;
                upgradeButtonInstance.transform.position = screenPosition;
            }

            if (TowerTestControl.instance.selected == true)
            {
                upgradeButtonInstance.SetActive(false);
                selectedUnit = null;
            }

            upgradeMoney.text = "Upgrade:" + upgradeCost.ToString();
        }
        else if (upgradeButtonInstance != null && upgradeButtonInstance.activeSelf)
        {
            // If selectedUnit is null and the upgrade button is still active, deactivate it
            upgradeButtonInstance.SetActive(false);
            selectedUnit = null;
        }

    }

    public void CloseUpgrade()
    {
        Debug.Log("close!");
        upgradeButtonInstance.SetActive(false);
        selectedUnit = null;
        allowButtonReactivation = false;
        StartCoroutine(AllowButtonReactivationAfterDelay(2f));
    }

    void Upgrade()
    {
        if (BuyButton.instance.money >= upgradeCost)
        {
            Debug.Log("up!");
            BuyButton.instance.money -= upgradeCost;
            tower_prototype.instance.damage++;
            upgradeButtonInstance.SetActive(false);
            selectedUnit = null;
            allowButtonReactivation = false;
            StartCoroutine(AllowButtonReactivationAfterDelay(2f));
            upgradeCost += 50;
            BuyButton.instance.UpdateMoneyDisplay();
        } else
        {
            Debug.Log("Upgrade Fail!");
            upgradeButtonInstance.SetActive(false);
            selectedUnit = null;
            allowButtonReactivation = false;
            StartCoroutine(AllowButtonReactivationAfterDelay(1f));
        }

    }

    IEnumerator AllowButtonReactivationAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        allowButtonReactivation = true;
    }



    void OnMouseEnter()
    {
        //isMouseOver = true;

        if (allowButtonReactivation && selectedUnit == null)
        {

            selectedUnit = this; // Set this unit as the selected unit
            upgradeButtonInstance.SetActive(true);
        }

    }


    //void OnMouseExit()
    //{
    //    if (selectedUnit != null)
    //    {
    //        isMouseOver = false;
    //        selectedUnit = null;
    //        upgradeButtonInstance.SetActive(false);
    //        StartCoroutine(DeactivateButtonAfterDelay(2f));
    //    }
    //}
    //IEnumerator DeactivateButtonAfterDelay(float delay)
    //{
    //    yield return new WaitForSeconds(delay);
    //    if (!isMouseOver) // Only deactivate if the mouse is still not over the GameObject
    //    {
    //        if (selectedUnit != null)
    //        {
    //            selectedUnit = null;
    //            upgradeButtonInstance.SetActive(false);
    //        }
    //    }
    //}



    //public static Vector3 GetSelectedUnitPosition()
    //{
    //    if (selectedUnit != null)
    //    {
    //        return selectedUnit.transform.position;
    //    }

    //    return Vector3.zero;
    //}
}
