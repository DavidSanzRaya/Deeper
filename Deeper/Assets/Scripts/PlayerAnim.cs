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

    // Update is called once per frame
    void LateUpdate()
    {
        SpriteFlip();
        Move();
    }

    private void SpriteFlip()
    {
        lookingRight = player.GetDirection();
        sprite.flipX = lookingRight;
    }

    private void Move()
    {
        anim.SetBool("Moving", player.Move != 0);
    }
}
