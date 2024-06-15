using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    //private Animator animator;
    private bool isDead = false;
    private string tag = "pincho";

    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pincho") )
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("he muerto uwu");
        isDead = true;
      //animator.SetTrigger("Die");
    }
}
