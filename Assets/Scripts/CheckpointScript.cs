using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public GameObject sphere;
    public Material redLight;
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private AudioSource checkpointSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && gameController.GetComponent<GameController>().WinCheck()) //Мне кажется так не стоит делать
        {
            
            sphere.GetComponent<MeshRenderer>().material = redLight; //Меняем цвет              
            gameObject.GetComponent<ParticleSystem>().Play();
            StartCoroutine(WaitForWin());
        }
    }

    IEnumerator WaitForWin()
    {
        yield return new WaitForSeconds(2);
        gameController.Win();
        checkpointSound.Play();
    }
}
