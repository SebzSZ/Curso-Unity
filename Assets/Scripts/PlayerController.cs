using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _playerSpeed;
    [SerializeField] private float _smoothTime;
    private Vector2 _input;
    private Vector2 _fixedInput;
    private Vector2 _currentVelocity = Vector2.zero;

    private Rigidbody2D _rb2D;
    private PlayerInput _playerInput;

    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        ReadInput();

        Debug.Log("Input: " + _input);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void ReadInput()
    {
        _input = _playerInput.actions["Move"].ReadValue<Vector2>();
    }

    private void Move()
    {
        // transform.position += new Vector3(_input.x, _input.y, 0) * _playerSpeed * Time.deltaTime;

        // _rb2D.linearVelocity = new Vector3(_input.x, _input.y, 0) * _playerSpeed;

        // _rb2D.MovePosition(_rb2D.position + new Vector2(_input.x, _input.y) * _playerSpeed * Time.fixedDeltaTime);

        // _rb2D.AddForce(new Vector2(_input.x, _input.y) * _playerSpeed);

        _fixedInput = Vector2.SmoothDamp(_fixedInput, _input, ref _currentVelocity, _smoothTime);
        _rb2D.MovePosition(_rb2D.position + _fixedInput * _playerSpeed * Time.fixedDeltaTime);
    }
}