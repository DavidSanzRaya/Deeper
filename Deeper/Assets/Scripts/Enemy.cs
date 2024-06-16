using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool asleep = true;

    [SerializeField]
    private Animator anim;
    [SerializeField]
    private GameObject pathStart;
    [SerializeField] 
    private GameObject pathEnd;

    private GameObject player;
    private Vector3 direction;
    private float lastDistanceFromTarget;
    private GameObject currentTarget;
    private bool animationEnded = false;

    [SerializeField]
    private float distanceFromPlayerToWakeUp;
    [SerializeField]
    private float velocity;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentTarget = pathStart;
        direction = (currentTarget.transform.position - transform.position).normalized;
        lastDistanceFromTarget = Vector2.Distance(transform.position, currentTarget.transform.position);
    }

    private void Update()
    {
        if (!asleep && animationEnded)
        {
            Move();
        }

        if (Vector2.Distance(player.transform.position, transform.position) < distanceFromPlayerToWakeUp)
        {
            if (asleep)
            {
                asleep = false;
                anim.SetTrigger("WakeUp");
            }
        }
        else
        {
            if (!asleep)
            {
                asleep = true;
                anim.SetTrigger("Sleep");
                animationEnded = false;
            }
        }
    }

    private void Move()
    {
        float distanceFromTarget = Vector2.Distance(transform.position, currentTarget.transform.position);
        transform.position += new Vector3(direction.x * velocity * Time.deltaTime, 0, 0);

        if (distanceFromTarget > lastDistanceFromTarget)
        {
            if (currentTarget == pathStart)
            {
                currentTarget = pathEnd;
                direction = (currentTarget.transform.position - transform.position).normalized;

            }
            else
            {
                currentTarget = pathStart;
                direction = (currentTarget.transform.position - transform.position).normalized;
            }
            distanceFromTarget = Vector2.Distance(transform.position, currentTarget.transform.position);
        }

        lastDistanceFromTarget = distanceFromTarget;
    }

    public void OnAnimationEnded()
    {
        animationEnded = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player;
        if (player = collision.GetComponent<Player>())
        {
            player.OnDie();
        }
    }
}
