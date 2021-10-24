using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLoopScript : MonoBehaviour
{
    private bool direction = true; //true вправо    
    private int arraySwitcher = 0;
    [SerializeField]
    private GameObject[] targets = new GameObject[7];
    [SerializeField]
    private AudioSource spinSound;

    public Vector3 NextTarget()
    {               
        if (direction) //Направление движение
        {
            arraySwitcher++; //Индекс следующей цели
            if (arraySwitcher == targets.Length)
            {
                return transform.right + targets[--arraySwitcher].transform.position; //Для последней цели
            }
            return targets[arraySwitcher].transform.position; //Возвращаем позицию следющей цели
        }
        else
        {
            arraySwitcher--;
            if (arraySwitcher < 0)
            {
                return transform.right*-1 + targets[++arraySwitcher].transform.position;
            }
            return targets[arraySwitcher].transform.position;
        }
        
    }
    public Vector3 NextTarget(GameObject firstCollider)
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (firstCollider.transform.position == targets[i].transform.position) //Ищем с какой стороны игрок
            {
                if (i < 3)
                {
                    arraySwitcher = 0;
                    direction = true;
                    targets[targets.Length-1].GetComponent<LoopAddForceScript>().isFirst = false;           //Выключаем другую сторону         

                }
                else
                {
                    arraySwitcher = targets.Length - 1;
                    direction = false;
                    targets[0].GetComponent<LoopAddForceScript>().isFirst = false;
                }
            }

        }
        StartCoroutine(BoolSwitcher()); //Ждем и включаем другую сторону
        spinSound.Play();
        return NextTarget();  
    }    
    IEnumerator BoolSwitcher()
    {
        yield return new WaitForSeconds(2);        
        targets[arraySwitcher].GetComponent<LoopAddForceScript>().isFirst = true;
        Debug.Log("Direction changed!");
    }
}
   
