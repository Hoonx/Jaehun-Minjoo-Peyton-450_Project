using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthFill;
    public Transform targetTransform;

    public void SetHealth(float currentHealth, float maxHealth)
    {
        float fillAmount = currentHealth / maxHealth;
        healthFill.fillAmount = fillAmount;
    }

    void Update()
    {
        if (targetTransform != null)
        {
            transform.position = targetTransform.position + new Vector3(0f, 2f, 0f);
        }
    }
}
