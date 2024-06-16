using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && gameObject.layer == 3)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Creditos");
        }

    }

}
