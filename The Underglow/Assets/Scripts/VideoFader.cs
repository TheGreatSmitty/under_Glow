using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoFader : MonoBehaviour
{
    public float wait_time = 6f;
    public int index;
    private void Start()
    {
        StartCoroutine(Wait_For_Video());
    
    }

    IEnumerator Wait_For_Video()
    {
        yield return new WaitForSeconds(wait_time);

        SceneManager.LoadScene(index);
    }
}
