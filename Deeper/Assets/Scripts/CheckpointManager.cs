using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{

    private static CheckpointManager checkpointManager;

    public static CheckpointManager instance
    {
        get
        {
            return RequestInstance();
        }
    }

    static CheckpointManager RequestInstance()
    {

        if (checkpointManager == null)
        {
            checkpointManager = FindObjectOfType<CheckpointManager>();

            if (checkpointManager == null)
            {
                GameObject gamelogicObject = new GameObject("CheckpointManager");
                checkpointManager = gamelogicObject.AddComponent<CheckpointManager>();
            }
        }
        return checkpointManager;
    }

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
            currentCheckpoint.GetComponent<Collider2D>().enabled = true;
        }
    }

    public Checkpoint GetCurrentCheckpoint()
    {
        return currentCheckpoint;
    }
}
