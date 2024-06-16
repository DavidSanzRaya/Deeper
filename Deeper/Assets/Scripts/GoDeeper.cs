using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GoDeeper : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player;
        if (player = collision.GetComponent<Player>())
        {
            player.OnGoDeeper();
        }

    }
}