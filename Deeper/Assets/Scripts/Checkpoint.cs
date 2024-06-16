using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] CheckpointManager manager;

    private Animator animator;

    private bool check = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        if(manager == null)
        {
            manager = FindObjectOfType<CheckpointManager>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("check");
            CheckpointManager.instance.NextLevel();
        }
        
    }
}
