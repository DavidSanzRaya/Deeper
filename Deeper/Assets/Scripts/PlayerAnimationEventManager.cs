using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEventManager : MonoBehaviour
{
    [SerializeField]
    private Player player;

    public void ActivateOnStoppingGoingDeeper()
    {
        player.OnStoppedGoingDeeper();   
    }
}
