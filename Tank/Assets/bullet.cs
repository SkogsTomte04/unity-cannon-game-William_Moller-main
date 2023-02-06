using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtExplisionParticle;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            ParticleSystem ex = Instantiate(explosionParticle, collision.GetContact(0).point, Quaternion.Euler(-90,0,0));
            Destroy(ex.gameObject, 2);
            Destroy(this.gameObject);

        }
        else if (collision.gameObject.tag == "Ground")
        {
            ParticleSystem ex = Instantiate(dirtExplisionParticle, collision.GetContact(0).point, Quaternion.Euler(-90, 0, 0));
            Destroy(ex.gameObject, 2);
            Destroy(this.gameObject);
        }
        
    }
}