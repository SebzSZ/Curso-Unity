using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Variables de movimiento
    [Header("Movimiento")]
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _smoothTime;
    [SerializeField] private float _speedMultiplier;
    private float _newSpeed;

    // Variables de disparo
    [Header("Disparo")]
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _shootCooldown;
    private float _isShooting;
    private float _shootTimer;

    // Lógica de movimiento
    private Vector2 _input;
    private Vector2 _fixedInput;
    private Vector2 _currentVelocity = Vector2.zero;
    private float _isRunning;

    // Componentes
    private Rigidbody2D _rb2D;
    private PlayerInput _playerInput;

    void Start()
    {
        // Asignación de componentes
        _rb2D = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        ReadInput();
        ApplySpeed();

        // Disparo
        _shootTimer += Time.deltaTime;
        if (_shootTimer >= _shootCooldown)
        {
            _shootTimer = 0;
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void ReadInput()
    {
        // Leer el input crudo
        _input = _playerInput.actions["Move"].ReadValue<Vector2>();
        _isRunning = _playerInput.actions["Run"].ReadValue<float>();
        _isShooting = _playerInput.actions["Shoot"].ReadValue<float>();
    }

    private void ApplySpeed()
    {
        if (_isRunning != 0)
        {
            _newSpeed = _playerSpeed * _speedMultiplier;
        }
        else
        {
            _newSpeed = _playerSpeed;
        }
    }

    private void Move()
    {
        // Suavizar el input mediante SmoothDamp
        // SmoothDamp(posActual, posObjetivo, ref velActual, tiempoLlegar)
        _fixedInput = Vector2.SmoothDamp(_fixedInput, _input, ref _currentVelocity, _smoothTime);
        _rb2D.MovePosition(_rb2D.position + _fixedInput * _newSpeed * Time.fixedDeltaTime);
    }

    private void Shoot()
    {
        if (_isShooting != 0)
        {
            Instantiate(_bullet, transform.position, transform.rotation);
        }
    }
}