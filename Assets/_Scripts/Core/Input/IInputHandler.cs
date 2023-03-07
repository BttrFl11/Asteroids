using System;
using UnityEngine;

public interface IInputHandler
{
    event Action OnShoot;
    event Action OnMove;
    event Action<float> OnRotate;

    void ReadInput();
}
