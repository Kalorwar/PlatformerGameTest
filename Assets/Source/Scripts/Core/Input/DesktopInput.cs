using System;
using UnityEngine;
using Zenject;

public class DesktopInput : IInput, ITickable
{
    public event Action OnClickUp;
    public event Action OnClickLeft;
    public event Action OnClickRight;
    public event Action OnClickDown;
    public event Action OnButtonUp;
    
    public void Tick()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            OnClickLeft?.Invoke();
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            OnClickRight?.Invoke();
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            OnClickUp?.Invoke();
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            OnClickDown?.Invoke();
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W)|| 
            Input.GetKeyUp(KeyCode.UpArrow)|| Input.GetKeyUp(KeyCode.LeftArrow)|| Input.GetKeyUp(KeyCode.RightArrow))
            OnButtonUp?.Invoke();
    }
}