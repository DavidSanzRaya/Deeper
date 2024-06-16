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

    private void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponentInChildren<Animator>();
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
    }

    private void UpdateAnimations()
    {
        anim.SetBool("Moving", player.Move != 0);
        anim.SetBool("Grounded", player.Grounded);
        anim.SetBool("Falling", player.Velocity.y < 0 && !player.Grounded);
    }
}
