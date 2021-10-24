using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    private bool direction;
    public int speed;
    private int arraySwitcher = 0;
    [SerializeField]
    private Vector3[] targets = new Vector3[2];

    
    void Start()
    {        
    }
    
    void Update()
    {
        if (arraySwitcher == targets.Length) //Переключаем направление при достижении конца массива
        {
            --arraySwitcher;
            direction = false;
        }
        if (arraySwitcher < 0) // При достижении начала массива
        {
            direction = true;
            ++arraySwitcher;
        }               
        transform.position = Vector3.MoveTowards(transform.position, targets[arraySwitcher], Time.deltaTime * speed); //Едем к цели
        if (transform.position == targets[arraySwitcher]) //Переключаем элементы подряд
        {
            if (direction)
            {
                arraySwitcher++;
            }
            else
            {
                arraySwitcher--;
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.transform.SetParent(gameObject.transform);
        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.transform.SetParent(null);
        }
        
    }
}
