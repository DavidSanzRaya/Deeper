using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GoDeeper : MonoBehaviour
{
    [SerializeField] 
    private LayersManager layerManger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player;
        if (player = collision.GetComponent<Player>())
        {
            player.OnGoDeeper();
        }
        layerManger.NextLevel();
    }
}