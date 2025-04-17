using System;
using System.Collections;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerController : MonoBehaviour
{
    public event EventHandler OnPause;
    public event EventHandler<int> OnScorePoints;
    public event EventHandler OnCrash;

    public float ThrustForce = 5.0f;

    [Header("Tilt")]
    public float TiltSpeed;
    public Quaternion MaxTilt;
    public Quaternion ResetTilt;

    private Rigidbody2D _playerRigidbody;
    private int _currentScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _currentScore = 0;

        StartCoroutine(TiltDownwards());
    }

    private void Update()
    {

    }

    public void Thrust(CallbackContext callback)
    {
        if (callback.phase == UnityEngine.InputSystem.InputActionPhase.Performed)
        {
            _playerRigidbody.linearVelocity = Vector2.zero;
            _playerRigidbody.AddForce(Vector2.up * ThrustForce, ForceMode2D.Impulse);

            transform.rotation = ResetTilt;
        }
    }

    public void Pause(CallbackContext callback)
    {
        if (callback.phase != UnityEngine.InputSystem.InputActionPhase.Performed)
            return;

        OnPause?.Invoke(this, EventArgs.Empty);
    }

    public void ResetPosition()
    {
        transform.SetPositionAndRotation(new Vector3(0, 0, 0),
                                           Quaternion.Euler(0, 0, -90));
    }

    private IEnumerator TiltDownwards()
    {
        while (Quaternion.Angle(transform.rotation, MaxTilt) > 0.01f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, MaxTilt, Time.deltaTime * TiltSpeed);
            yield return null;
        }

        transform.rotation = MaxTilt;
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        OnCrash?.Invoke(this, EventArgs.Empty);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        _currentScore += 100;
        OnScorePoints?.Invoke(this, _currentScore);
    }
}
