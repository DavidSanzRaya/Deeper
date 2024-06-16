using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public static event Action OnEndDeathAnimation;
    public void DeleteVFX()
    {
        Destroy(gameObject);
        OnEndDeathAnimation?.Invoke();
    }
}
