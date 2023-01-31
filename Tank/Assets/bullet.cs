using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class bullet : MonoBehaviour
{
    void Start()
    {

    }

    public ParticleSystem BOOM;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ParticleSystem ex = Instantiate(BOOM, collision.GetContact(0).point, Quaternion.Euler(-90,0,0));
            Destroy(ex.gameObject, 2);
            Destroy(this.gameObject);
        }
    }
}