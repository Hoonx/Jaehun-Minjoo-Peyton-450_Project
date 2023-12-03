using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitUpgrade : MonoBehaviour
{
    public GameObject upgradeButtonPrefab; // Reference to the upgrade button prefab
    private GameObject upgradeButtonInstance; // Instance of the button

    private Button closeButton;
    public int upgradeCost = 100;

    private TMP_Text upgradeMoney;
    public Vector3 offset;

    private Coroutine hoverCoroutine;

    void Start()
    {
        //upgradeButtonInstance = Instantiate(upgradeButtonPrefab, FindObjectOfType<Canvas>().transform);

        Button upgradeButton2 = upgradeButtonInstance.GetComponent<Button>();
        upgradeButton2.onClick.AddListener(Upgrade);

        closeButton = upgradeButtonInstance.transform.Find("CloseButton").GetComponent<Button>();
        closeButton.onClick.AddListener(CloseUpgrade);

        upgradeMoney = upgradeButtonInstance.transform.Find("UpgradeText").GetComponent<TMP_Text>();

        //upgradeButtonInstance.SetActive(false);
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
        if (upgradeButtonInstance != null && upgradeButtonInstance.activeSelf)
        {
            //Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position + offset);
            //upgradeButtonInstance.transform.position = screenPosition;

            Vector3 screenPosition = transform.position;
            upgradeButtonInstance.transform.position = screenPosition;
        }
    }



    private void StopAndResetCoroutine()
    {
        if (hoverCoroutine != null)
        {
            StopCoroutine(hoverCoroutine);
            hoverCoroutine = null;
        }
        if (upgradeButtonInstance != null)
        {
            upgradeButtonInstance.SetActive(false);
        }
    }



    public void CloseUpgrade()
        {
        upgradeButtonInstance.SetActive(false);
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
            BuyButton.instance.money -= upgradeCost;
            tower_prototype.instance.damage++;
            upgradeCost += 50;
            BuyButton.instance.UpdateMoneyDisplay();
        }
        upgradeButtonInstance.SetActive(false);
        if (hoverCoroutine != null)
        {
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
        if (upgradeButtonInstance != null)
        {
            Debug.Log("Activating upgrade button");
            upgradeButtonInstance.SetActive(true);
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
        if (upgradeButtonInstance != null)
        {
            Destroy(upgradeButtonInstance);
        }
    }
}
