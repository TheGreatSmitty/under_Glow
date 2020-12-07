using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class QuitScript : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey("escape")) Application.Quit();

    }
}
