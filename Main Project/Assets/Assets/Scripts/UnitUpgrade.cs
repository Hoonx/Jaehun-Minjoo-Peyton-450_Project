using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitUpgrade : MonoBehaviour
{
    //public GameObject upgradeButtonPrefab; // Reference to the upgrade button prefab
    //private GameObject upgradeButtonInstance; // Instance of the button
    private Button upgradeButton; // Reference to the upgrade button
    private Button closeButton;

    //private Button closeButton;
    public int upgradeCost = 100;

    private TMP_Text upgradeMoney;
    public Vector3 offset;

    private Coroutine hoverCoroutine;

    void Start()
    {
        upgradeButton = GetComponentInChildren<Button>(true);
        if (upgradeButton != null)
        {
            upgradeButton.onClick.AddListener(Upgrade);
            upgradeMoney = upgradeButton.GetComponentInChildren<TMP_Text>(true);
            closeButton = upgradeButton.transform.Find("CloseButton").GetComponent<Button>();
            closeButton.onClick.AddListener(CloseUpgrade);
        }
        else
        {
            Debug.LogError("Upgrade button not found in children.");
        }

        if (upgradeButton != null)
            upgradeButton.gameObject.SetActive(false); // Initially set the button to inactive
    }

    void Update()
    {
        Vector2 rayPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Define a layer mask for the raycast to only consider the "Units" layer
        int layerMask = LayerMask.GetMask("Units");

        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, Mathf.Infinity, layerMask);

        Debug.Log("Raycast hit: " + (hit.collider != null ? hit.collider.gameObject.name : "None"));

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            upgradeMoney.text = "Upgrade:" + upgradeCost.ToString();
            Debug.Log("Hovering over this tower's Collider");
            if (hoverCoroutine == null)
            {
                hoverCoroutine = StartCoroutine(ActivateButtonAfterDelay(2f));
            }
        }
        else
        {
            if (hoverCoroutine != null)
            {
                StopAndResetCoroutine();
            }
        }
        if (upgradeButton != null && upgradeButton.gameObject.activeInHierarchy)
        {
            //Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position + offset);
            //upgradeButtonInstance.transform.position = screenPosition;

            //Vector3 screenPosition = transform.position;
            //upgradeButton.transform.position = screenPosition;
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position + offset);
            
            upgradeButton.transform.position = Camera.main.WorldToScreenPoint(transform.position + offset);
            screenPosition.z = 5;

        }
    }



    private void StopAndResetCoroutine()
    {
        if (hoverCoroutine != null)
        {
            StopCoroutine(hoverCoroutine);
            hoverCoroutine = null;
        }
        if (upgradeButton != null)
        {
            upgradeButton.gameObject.SetActive(false);
        }
    }



    public void CloseUpgrade()
        {
        upgradeButton.gameObject.SetActive(false);
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
            Debug.Log("up");
            BuyButton.instance.money -= upgradeCost;
            tower_prototype.instance.damage++;
            upgradeCost += 50;
            BuyButton.instance.UpdateMoneyDisplay();
        }
        upgradeButton.gameObject.SetActive(false);
        if (hoverCoroutine != null)
        {
            Debug.Log("upgrade fail");
            StopCoroutine(hoverCoroutine);
            hoverCoroutine = null;
        }
        CloseUpgrade();
    }

    //void OnMouseEnter()
    //{
    //    if (hoverCoroutine != null)
    //    {
    //        StopCoroutine(hoverCoroutine);
    //    }
    //    hoverCoroutine = StartCoroutine(ActivateButtonAfterDelay(2f));
    //}

    IEnumerator ActivateButtonAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (upgradeButton != null)
        {
            Debug.Log("Activating upgrade button");
            upgradeButton.gameObject.SetActive(true);

        }
        else
        {
            Debug.Log("Upgrade button instance is null");
        }
    }

    void OnDestroy()
    {
        if (hoverCoroutine != null)
        {
            StopCoroutine(hoverCoroutine);
        }
        if (upgradeButton != null)
        {
            Destroy(upgradeButton);
        }
    }
}
