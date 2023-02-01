using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Image _healthbarSprite;

    void Start()
    {

    }
    public void UpdateHealth(float maxHealth, float currentHealth)
    {
        _healthbarSprite.fillAmount = currentHealth / maxHealth;
    }

    void Update()
    {
        if(Camera.current !=null)
        {
            transform.rotation = Quaternion.LookRotation(transform.position - Camera.current.transform.position);
        }
        
    }
}
