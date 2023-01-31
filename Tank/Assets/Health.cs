using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Image _healthbar;
    [SerializeField] private float _reduceSpeed;
    private Camera Camera;
    private float _target = 1;

    private void Start()
    {
        Camera = Camera.current;
    }

    public void Updatehealthbar(float maxhealth, float currenthealth)
    {
        _healthbar.fillAmount = currenthealth / maxhealth;
    }
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - Camera.transform.position);
        //_healthbar.fillAmount = Mathf.MoveTowards(_healthbar.fillAmount, _reduceSpeed * Time.deltaTime);
    }
}
