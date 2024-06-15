using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Player player;

    [SerializeField] private Checkpoint[] checkpoints;

    private Checkpoint currentCheckpoint;

    private int currentLevel = 0;

    private void Awake()
    {
        currentCheckpoint = checkpoints[0];
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    [ContextMenu("NextLevel")]
    public void NextLevel()
    {
        if (currentLevel < checkpoints.Length)
        {
            currentCheckpoint.GetComponent<Collider2D>().enabled = false;
            currentLevel++;
            currentCheckpoint = checkpoints[currentLevel];
            checkpoints[currentLevel].GetComponent<Collider2D>().enabled = true;
        }
    }

    public void Respawn()
    {
        player.transform.position = currentCheckpoint.transform.position;
    }
}
