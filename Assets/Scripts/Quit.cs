using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public void QuitGame(bool quit) 
    {
        if (quit)
        {
            Debug.Log("Exiting Game");
            Application.Quit();
        }
    }
}
