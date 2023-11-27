// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class HealthBar : MonoBehaviour
// {
//     public Image healthFill;
//     public Transform targetTransform;

//     public void SetHealth(float currentHealth, float maxHealth)
//     {
//         float fillAmount = currentHealth / maxHealth;
//         healthFill.fillAmount = fillAmount;
//     }

//     void Update()
//     {
//         if (targetTransform != null)
//         {
//             transform.position = targetTransform.position + new Vector3(0f, 2f, 0f);
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider Slider;
    public Vector3 Offset;

    public void SetHealth(float health, float maxHealth)
    {
        Slider.gameObject.SetActive(health < maxHealth);
        Slider.value = health;
        Slider.maxValue = maxHealth;
    }

    void Update()
    {
        Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }
}