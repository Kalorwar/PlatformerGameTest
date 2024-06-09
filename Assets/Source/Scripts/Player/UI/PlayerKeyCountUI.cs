using TMPro;
using UnityEngine;

public class PlayerKeyCountUI : MonoBehaviour
{ 
    [SerializeField] private TextMeshProUGUI _keyCount;
    public int KeyAmount { get; private set; }

    public void KeyCountChange()
    {
        _keyCount.text = $"Keys collected: {KeyAmount += 1} /5";
    }
}