using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerContoller>().ChangeGCStats(0,1);
            Vector3 position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
            other.transform.position = new Vector3(position.x,position.y,position.z); //Тут немного не уверен
        }
    }
}
