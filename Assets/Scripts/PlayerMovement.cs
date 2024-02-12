using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _groundDrag;

    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpCooldown;
    [SerializeField] private float _airMultiplier;
    private bool _readyToJump = true;

    private KeyCode _jumpKey = KeyCode.Space;

    [SerializeField] private Transform _orientation;

    private float _horizontalInput;
    private float _verticalInput;

    private Vector3 _moveDirection;

    private Rigidbody _rigidbody;


    [Header("Ground Check")]
    [SerializeField] private float _playerHeight;
    [SerializeField] private LayerMask _whatIsGround;
    private bool _grounded;


    private void Start()
    {
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

        if (Input.GetKey(_jumpKey) && _readyToJump && _grounded)
        {
            _readyToJump = false;

            Jump();
            if (_grounded)
            {
                ResetJump();
            }
        }
    }
    // онялнрперэ бхдня опн сопюбкемхе б йспяе!!!!
    private void MovePlayer()
    {
        _moveDirection = _orientation.forward * _verticalInput + _orientation.right * _horizontalInput;

        float speedMultiplier = 10f;
        if(_grounded)
        _rigidbody.AddForce(_moveDirection.normalized * _moveSpeed * speedMultiplier, ForceMode.Force);
        else
        {
            _rigidbody.AddForce(_moveDirection.normalized * _moveSpeed * speedMultiplier * _airMultiplier, ForceMode.Force);
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

    private void Jump()
    {
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z);

        _rigidbody.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
    }

    private void ResetJump() 
    {
        _readyToJump = true;
    }
}

