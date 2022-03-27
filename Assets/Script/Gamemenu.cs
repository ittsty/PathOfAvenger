using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemenu : MonoBehaviour
{
    [SerializeField]private GameObject credit;  
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Credit_open()
    {
        credit.gameObject.SetActive(true);
    }
    public void Credit_close()
    {
        credit.gameObject.SetActive(false);
    }
}
