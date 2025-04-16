using System;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerController : MonoBehaviour
{
    public event EventHandler OnPause;
    public float ThrustForce = 5.0f;

    private Rigidbody2D _playerRigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Thrust(CallbackContext callback)
    {
        if (callback.phase == UnityEngine.InputSystem.InputActionPhase.Performed)
        {
            _playerRigidbody.linearVelocity = Vector2.zero;
            _playerRigidbody.AddForce(Vector2.up * ThrustForce, ForceMode2D.Impulse);
        }
    }

    public void Pause(CallbackContext callback)
    {
        if (callback.phase != UnityEngine.InputSystem.InputActionPhase.Performed)
            return;

        OnPause?.Invoke(this, EventArgs.Empty);
    }
}
