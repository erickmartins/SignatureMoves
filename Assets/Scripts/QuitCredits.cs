using UnityEngine;
using System.Collections;

public class QuitCredits : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("MainMenu");
        }
    }

    
}