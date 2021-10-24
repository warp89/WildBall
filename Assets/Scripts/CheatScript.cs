using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatScript : MonoBehaviour
{
    [SerializeField]
    private GameObject hiddenButton;
    private string cheatCode = "UpArrowUpArrowDownArrowDownArrowUpArrowUpArrowUpArrowUpArrow";
    private string inputCode;

    private void Start()
    {
        Debug.Log(cheatCode);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            inputCode += KeyCode.UpArrow.ToString();
            if (inputCode == cheatCode && !hiddenButton.activeSelf)
            {
                hiddenButton.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            inputCode += KeyCode.DownArrow.ToString();
            if (inputCode == cheatCode && !hiddenButton.activeSelf)
            {
                hiddenButton.SetActive(true);
            }
        }        
    }
}
