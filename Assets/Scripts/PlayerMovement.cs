using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    [Header("Movement")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _groundDrag;


    [SerializeField] private Transform _orientation;

    private float _horizontalInput;
    private float _verticalInput;

    private Vector3 _moveDirection;

    private Rigidbody _rigidbody;


    [Header("Ground Check")]
    [SerializeField] private float _playerHeight;
    [SerializeField] private LayerMask _whatIsGround;
    private bool _grounded;

    [SerializeField] private float _timerDown = 0.001f;
    [SerializeField] private float _timer = 0.1f;
    [SerializeField] private AudioClip[] _clip;
    public bool CanMove => _canMove;
    private bool _canMove = true;

    private void Start()
    {
        Instance = this;

        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
    }

    private void Update()
    {
        GroundCheck();
        MyInput();
        SpeedControl();

        if (_grounded)
            _rigidbody.drag = _groundDrag;
        else
            _rigidbody.drag = 0;
    }

    private void FixedUpdate()
    {
        if (_canMove)
            MovePlayer();
    }
    private void GroundCheck()
    {
        float playerHalf = 0.5f;
        float additionalLength = 0.2f;

        _grounded = Physics.Raycast(transform.position, Vector3.down, _playerHeight * playerHalf * additionalLength, _whatIsGround);

    }

    private void MyInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
    }
    // онялнрперэ бхдня опн сопюбкемхе б йспяе!!!!
    private void MovePlayer()
    {
        _moveDirection = _orientation.forward * _verticalInput + _orientation.right * _horizontalInput;

        float speedMultiplier = 10f;
        if (_grounded)
            _rigidbody.AddForce(_moveDirection.normalized * _moveSpeed * speedMultiplier, ForceMode.Force);

        if (_moveDirection.normalized.x != 0 || _moveDirection.normalized.z != 0)
        {
            MoveSound();
        }

    }

    private void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z);

        if (flatVelocity.magnitude > _moveSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * _moveSpeed;
            _rigidbody.velocity = new Vector3(limitedVelocity.x, _rigidbody.velocity.y, limitedVelocity.z);
        }
    }

    public void ToggleMovement()
    {
        _canMove = !_canMove;
    }

    private void MoveSound()
    {
        if (_timerDown > 0)
        {
            _timerDown -= Time.deltaTime;
        }

        if (_timerDown < 0)
        {
            SoundsController.Instance.PlaySound(_clip[Random.Range(0, _clip.Length)]);
            _timerDown = _timer;
        }
    }
}

