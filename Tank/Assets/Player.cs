using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 3;
    private float _currentHealth;

    [SerializeField] private Health _healthbar;
    public Transform Gun;
    public GameObject bulletprefab;
    public float rotationspeed;
    public float maxrotation;
    public float minrotation;
    public float movspeed;
    public float bulletvel;
    public float Damage;
    private Vector3 Mov_Input;

    public Transform gun;
    public Transform barrel;
    public Camera playerCamera;

    float barrelRotation = 0;

    Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(_healthbar);
        rigidBody = GetComponent<Rigidbody>();
        
        _currentHealth = 1;

        _healthbar.UpdateHealth(_maxHealth, _currentHealth);
    }
    Vector3 force(float bulletSpeed)
    {
        return bulletSpeed * barrel.up;
    }
    
    void Update()
    {
        Mov_Input = new Vector3(Input.GetAxis("Vertical"), 0f);
        
        //Old movement system
        /*
        if (Input.GetKey("d") && gameObject.tag == "Player")
        {
            transform.Rotate(0, rotationspeed * Time.deltaTime, 0);
        }
        if (Input.GetKey("a") && gameObject.tag == "Player")
        {
            transform.Rotate(0, -rotationspeed * Time.deltaTime, 0);
        }
        if (Input.GetKey("w") && gameObject.tag == "Player")
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * -movspeed);
        }
        if (Input.GetKey("s") && gameObject.tag == "Player")
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * movspeed);
        }
        if (Input.GetKey("q"))
        {
            Gun.Rotate(rotationspeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("e"))
        {
            Gun.Rotate(-rotationspeed * Time.deltaTime, 0, 0);
        }*/

        //Debug.Log(gun.localRotation.eulerAngles);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate<GameObject>(bulletprefab, barrel.position, barrel.rotation);
            bullet.transform.localRotation = barrel.rotation;
            bullet.GetComponent<Rigidbody>().AddForce(force(bulletvel), ForceMode.Impulse);
        }
        if (Input.GetKey("d") && gameObject.tag == "Player")
        {
            transform.Rotate(0, rotationspeed * Time.deltaTime, 0);
        }
        if (Input.GetKey("a") && gameObject.tag == "Player")
        {
            transform.Rotate(0, -rotationspeed * Time.deltaTime, 0);
        }
        if (Input.GetKey("q"))
        {
            barrelRotation += rotationspeed * Time.deltaTime;
            //Gun.Rotate(rotationspeed * 0, 0, Time.deltaTime);
        }
        if (Input.GetKey("e"))
        {
            barrelRotation -= rotationspeed * Time.deltaTime;
            //Gun.Rotate(-rotationspeed * 0, 0, Time.deltaTime);
        }
        if(Input.GetKeyDown("l"))
        {
            _currentHealth -= 1;
        }

        barrelRotation = Mathf.Clamp(barrelRotation, minrotation, maxrotation);
        Gun.localRotation = Quaternion.AngleAxis(barrelRotation, Vector3.forward);
        Player_Move();

    }
    private void Player_Move()
    {
        Vector3 MoveVector = transform.TransformDirection(Mov_Input) * -movspeed;
        rigidBody.velocity = new Vector3(MoveVector.x, rigidBody.velocity.y, MoveVector.z);

    }
    private void Player_rotate()
    {
       /*
        if (Input.GetKey("d") && gameObject.tag == "Player")
        {
            transform.rotation = (0, rotationspeed * Time.deltaTime, 0);
        }
        if (Input.GetKey("a") && gameObject.tag == "Player")
        {
            transform.Rotate(0, -rotationspeed * Time.deltaTime, 0);
        }*/
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            _currentHealth -= 1;
        }
    }*/
    

}