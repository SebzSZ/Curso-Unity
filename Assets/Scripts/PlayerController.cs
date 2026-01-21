using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _playerSpeed;
    private Vector2 _input;

    private PlayerInput _playerInput;

    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        ReadInput();

        Debug.Log("Input: " + _input);
    }

    private void ReadInput()
    {
        _input = _playerInput.actions["Move"].ReadValue<Vector2>();
    }
}