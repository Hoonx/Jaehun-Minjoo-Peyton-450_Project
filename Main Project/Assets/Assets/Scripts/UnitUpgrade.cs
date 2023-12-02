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


    private Button closeButton;
    public int upgradeCost =100;

    private TMP_Text upgradeMoney;
    public Vector3 offset;

    private Coroutine hoverCoroutine;

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
        if (hoverCoroutine != null)
        {
            StopCoroutine(hoverCoroutine);
            hoverCoroutine = null;
        }
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
            upgradeCost += 50;
            BuyButton.instance.UpdateMoneyDisplay();
            if (hoverCoroutine != null)
            {
                StopCoroutine(hoverCoroutine);
                hoverCoroutine = null;
            }
        } else
        {
            Debug.Log("Upgrade Fail!");
            upgradeButtonInstance.SetActive(false);
            selectedUnit = null;

        }

    }



    void OnMouseEnter()
    {
        //isMouseOver = true;
        Debug.Log("Mouse Enter");

        if (selectedUnit == null)
        {

            selectedUnit = this; // Set this unit as the selected unit
            hoverCoroutine = StartCoroutine(ActivateButtonAfterDelay(2f));
        }

    }

    IEnumerator ActivateButtonAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        if (selectedUnit != null && upgradeButtonInstance != null)
        {
            upgradeButtonInstance.SetActive(true);
        }
    }

    void OnDestroy()
    {
        // Stop the coroutine when the GameObject is destroyed
        if (hoverCoroutine != null)
        {
            StopCoroutine(hoverCoroutine);
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


}
