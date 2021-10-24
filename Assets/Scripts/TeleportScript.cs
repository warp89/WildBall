using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    [SerializeField]
    private GameObject anotherHole;
    [SerializeField]
    private bool direction;
    [SerializeField]
    private AudioSource spinSound;
    private void OnTriggerEnter(Collider other)
    {
        spinSound.Play();
        if (direction)
        {
            other.transform.position = anotherHole.transform.position + new Vector3(1.6f, 0, 0);
        }
        else
        {
            other.transform.position = anotherHole.transform.position + new Vector3(-1.6f, 0, 0);
        }
       
    }
}
