using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private bool lookingRight;

    [SerializeField]
    private SpriteRenderer sprite;

    private Animator anim;

    Vector2 colliderOffset;

    private void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponentInChildren<Animator>();
        colliderOffset = player.GetComponent<BoxCollider2D>().offset;
    }

    void LateUpdate()
    {
        SpriteFlip();
        UpdateAnimations();
    }

    private void SpriteFlip()
    {
        lookingRight = player.GetDirection();
        sprite.flipX = lookingRight;
        if (lookingRight)
        {
            if (player.GetComponent<BoxCollider2D>().offset == colliderOffset)
                player.GetComponent<BoxCollider2D>().offset = new Vector2(-colliderOffset.x, player.GetComponent<BoxCollider2D>().offset.y);
        }
        else
            player.GetComponent<BoxCollider2D>().offset = colliderOffset;


    }

    private void UpdateAnimations()
    {
        anim.SetBool("Moving", player.Move != 0);
        anim.SetBool("Grounded", player.Grounded);
        anim.SetBool("Falling", player.Velocity.y < 0 && !player.Grounded);
    }
}
