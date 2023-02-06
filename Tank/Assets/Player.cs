using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Health variables
    [SerializeField] private Health healthBar;
    [SerializeField] private float maxHealth = 3;
    private float currentHealth;

    // Shooting variables
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletVelocity;
    [SerializeField] private float damage;

    // Movement variables
    [SerializeField] private float moveSpeed;
    private Vector3 moveInput;

    // Turret and barrel rotation variables
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float maxRotation;
    [SerializeField] private float minRotation;
    [SerializeField] private Transform barrel;
    [SerializeField] private Transform turret;
    private float barrelRotation = 0;
    
    Rigidbody rigidbody;

    void Start()
    {
        Debug.Log(healthBar);
        rigidbody = GetComponent<Rigidbody>();
        
        currentHealth = maxHealth;

        healthBar.UpdateHealth(maxHealth, currentHealth);
    }
    Vector3 force(float bulletSpeed)
    {
        return bulletSpeed * barrel.up;
    }
    
    void Update()
    {
        healthBar.UpdateHealth(maxHealth, currentHealth);
        
        HandleInput();
        PlayerMoveAndRotate();
    }

    private void HandleInput()
    {
        moveInput = new Vector3(Input.GetAxis("Vertical"), 0f);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate<GameObject>(bulletPrefab, barrel.position, barrel.rotation);
            bullet.transform.localRotation = barrel.rotation;
            bullet.GetComponent<Rigidbody>().AddForce(force(bulletVelocity), ForceMode.Impulse);
        }
        if (Input.GetKey("d") && gameObject.tag == "Player")
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey("a") && gameObject.tag == "Player")
        {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey("q"))
        {
            barrelRotation += rotationSpeed * Time.deltaTime;
        }
        if (Input.GetKey("e"))
        {
            barrelRotation -= rotationSpeed * Time.deltaTime;
        }
        if (Input.GetKey("l"))
        {
            currentHealth -= 1;
        }
    }

    private void PlayerMoveAndRotate()
    {
        barrelRotation = Mathf.Clamp(barrelRotation, minRotation, maxRotation);
        turret.localRotation = Quaternion.AngleAxis(barrelRotation, Vector3.forward);

        Vector3 moveVector = transform.TransformDirection(moveInput) * -moveSpeed;
        rigidbody.velocity = new Vector3(moveVector.x, rigidbody.velocity.y, moveVector.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            currentHealth -= 1;
        }
    }
}