using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class J_HealthBar : MonoBehaviour
{
    public Slider Slider;
    public Color Low;
    public Color High;
    public Vector3 Offset;

    // Ensure that the Slider is initialized in Start to avoid potential race conditions
    void Start()
    {
        if (Slider == null)
        {
            Slider = GetComponentInChildren<Slider>();
            if (Slider == null)
            {
                Debug.LogError("Slider component not found. Please assign it in the Unity Editor.");
                return;
            }
        }
    }

    public void SetHealth(float health, float maxHealth)
    {
        if (Slider == null)
        {
            Debug.LogError("Slider component not assigned. Please assign it in the Unity Editor.");
            return;
        }

        Slider.gameObject.SetActive(health < maxHealth);
        Slider.value = health;
        Slider.maxValue = maxHealth;
        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, Slider.normalizedValue);
    }

    void Update()
    {
        if (Slider == null)
        {
            Debug.LogError("Slider component not assigned. Please assign it in the Unity Editor.");
            return;
        }

        // Ensure that the parent transform is not null before accessing its position
        if (transform.parent != null)
        {
            Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
        }
        else
        {
            Debug.LogError("Parent transform is null. Please check the parent GameObject.");
        }
    }
}