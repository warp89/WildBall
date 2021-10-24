using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoopAddForceScript : MonoBehaviour
{
    [SerializeField]
    public bool isFirst; //Отмечаем крайние триггеры
    [SerializeField]
    private int speed = 4; //Ускорение
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Vector3 heading;
            if (isFirst)
            {
                heading = transform.GetComponentInParent<SpeedLoopScript>().NextTarget(gameObject) - other.transform.position; //Если первый, передаем с gameObject
            }
            else
            {
                heading = transform.GetComponentInParent<SpeedLoopScript>().NextTarget() - other.transform.position;
            }            
            other.GetComponent<Rigidbody>().AddForce(heading * speed, ForceMode.Impulse); //Ускорение в сторону следующего
        }

    }
}
