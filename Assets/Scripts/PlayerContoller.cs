using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    private Rigidbody rigidbidy;
    private Vector3 movement;
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private AudioSource jump;

    public int speed = 10;
    public float jumpForce = 5;
    private bool isGround = false;    

    private void Awake()
    {
        rigidbidy = GetComponent<Rigidbody>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGround = true;
        } 
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGround = false;
        }
    }

    private void Jumping(bool isGrounded)
    {
        if (isGrounded)
        {
            rigidbidy.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            jump.Play();
        }
    }

    void FixedUpdate()
    {              
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        rigidbidy.AddForce(new Vector3(vertical * speed, 0, -horizontal * speed));
        if (Input.GetKey(KeyCode.Space))
        {
            Jumping(isGround);
        }
    }

    /// <summary>
    /// Не придумал как менять значения в GameController напрямую, поэтому меняю через игрока
    /// </summary>
    /// <param name="addRing"></param>
    /// <param name="loseLive"></param>
    public void ChangeGCStats(int addRing,int loseLive)
    {
        if (addRing>0)
        {
            gameController.AddRing();
        }
        if (loseLive>0)
        {
            gameController.LoseLife();
        }
               
    }
    
}
