using System;

public interface IInput 
{
    public event Action OnClickUp;
    public event Action OnClickLeft;
    public event Action OnClickRight;
    public event Action OnClickDown;
    public event Action OnButtonUp;
}