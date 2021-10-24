using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingScript : MonoBehaviour
{
    
    [SerializeField] private Animator animator;     


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {                        
            other.GetComponent<PlayerContoller>().ChangeGCStats(1,0);
            animator.SetBool("Getting", true);           
            StartCoroutine(Destroing());
        }
    }
    
    IEnumerator Destroing()
    {
        yield return new WaitForSeconds(0.33f);
        Destroy(gameObject.transform.parent.gameObject.transform.parent.gameObject); //”ничтожает "корневой" обьект
    }
}
