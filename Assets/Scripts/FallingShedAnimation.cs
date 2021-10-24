using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingShedAnimation : MonoBehaviour
{   
    [SerializeField]
    private Animator animator;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            StartCoroutine(StartFalling());
        }
    }
    IEnumerator StartFalling()
    {
        yield return new WaitForSeconds(0.6f);
        GoFalling();
    }

    private void GoFalling()
    {
        animator.SetBool("Fall", true);
    }

}
