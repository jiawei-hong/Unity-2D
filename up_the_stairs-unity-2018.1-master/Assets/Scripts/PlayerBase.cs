using UnityEngine;
using System;

public abstract class PlayerBase : MonoBehaviour
{
    public Action onGameOver;

    public bool isGrounded;

    public abstract void Stop();
}
