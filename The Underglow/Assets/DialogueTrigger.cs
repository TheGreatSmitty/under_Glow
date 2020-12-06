using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject child;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision);
        if (collision.gameObject.CompareTag("Player")) 
        child.SetActive(true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            child.SetActive(false);
    }
}
