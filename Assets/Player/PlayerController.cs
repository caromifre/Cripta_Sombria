using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : PlayerBehaviour
{
    [SerializeField] private Transform cam;

    // CharacterController _character;

    float _vMove;
    float _hMove;
    Vector3 _direction;
    float _turnSmoothTime;
    float _targetAngle;
    float _characterAngle;
    float _characterSpeed;
    float _turnSmoothVelocity;
    //float _gravity = -9.8f;
    //float _velocity;

    private void Start()
    {
        _characterSpeed = 3f;
        _turnSmoothVelocity = 0.2f;
        cam = Camera.main.transform;
    }

    private void Update()
    {
        Controller();
        //apply gravity so character can always be on floor
        //if(!_character.isGrounded)
        //{
        //   _velocity = _gravity * Time.deltaTime;

        //}
        //else
        //{
        //    _velocity = 0f;
        //}
        
        //Input Keyboard
        //_hMove = Input.GetAxis("Horizontal") * -1;
        //_vMove = Input.GetAxis("Vertical") * -1;

        ////Calculate movement and direction
        //_direction = new Vector3(_hMove, _velocity, _vMove).normalized;

        //if(_direction.magnitude >= 0.1f)
        //{
        //    _targetAngle = Mathf.Atan2(_direction.x,_direction.z) * Mathf.Rad2Deg;
        //    _characterAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref _turnSmoothTime, _turnSmoothVelocity);
           
        //    transform.rotation = Quaternion.Euler(0f,_characterAngle,0f);

        //    _character.Move(_direction * _characterSpeed * Time.deltaTime);
        //}

        //if(Input.GetKey(KeyCode.LeftShift))
        //{
        //    _direction *= 3; 
        //}
 
        ////Control de Animaciones
        //_anim.SetFloat("WalkVelocity",_direction.magnitude, 0.05f, Time.deltaTime);
    }

    // Controles de juego
    private void Controller()
    {
        // Ingreso del jugador
        _hMove = Input.GetAxisRaw("Horizontal");
        _vMove = Input.GetAxisRaw("Vertical");

        // Roto el personaje segun la direccion de la camara
        _targetAngle = cam.eulerAngles.y;
        _characterAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);

        transform.rotation = Quaternion.Euler(0f, _characterAngle, 0f);

        Vector3 moveDirection = cam.transform.forward * _vMove + cam.transform.right * _hMove;
        
        moveDirection.y = 0f;

        transform.Translate(moveDirection.normalized * _characterSpeed * Time.deltaTime, Space.World);


        // Sprint (Aumentar velocidad)
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _characterSpeed = 5;
        }
        else
        {
            _characterSpeed = 3;
        }
        // Idle
        if (_hMove == 0 && _vMove == 0)
        {
            _anim.SetBool("Walk",false);
        }
        // Caminar
        if ((_hMove != 0 || _vMove != 0) && (!Input.GetButtonDown("Fire1")) && (!Input.GetButtonDown("Fire2")))
        {
            _anim.SetBool("Walk", true);
        }
    }
}
