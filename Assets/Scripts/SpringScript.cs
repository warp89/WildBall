using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringScript : MonoBehaviour

    
{
    [SerializeField]
    private AudioSource springSound;
    public float springForce = 25;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {            
            collision.collider.GetComponent<Rigidbody>().AddForce(new Vector3(0,springForce,0),ForceMode.Impulse);
            springSound.Play();
        }
    }
}
