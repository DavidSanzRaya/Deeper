using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player;
        if(collision.TryGetComponent<Player>(out player))
        {
            player.OnDie();
        }
    }
}
