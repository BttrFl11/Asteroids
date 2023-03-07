using UnityEngine;
using System;

public class InputHandler : MonoBehaviour, IInputHandler
{
    public event Action OnShoot;
    public event Action OnMove;
    public event Action<float> OnRotate;

    private void Update()
    {
        ReadInput();
    }

    public void ReadInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            OnShoot?.Invoke();

        if (Input.GetKey(KeyCode.W))
            OnMove?.Invoke();

        if (Input.GetKey(KeyCode.D))
            OnRotate?.Invoke(-1f);
        else if (Input.GetKey(KeyCode.A))
            OnRotate?.Invoke(1f);
    }
}