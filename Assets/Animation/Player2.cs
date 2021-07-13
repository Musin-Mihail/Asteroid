using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public Animator _animator;
    public int _moveForward;
    public int _moveBack;
    public int _moveLeft;
    public int _moveRight;
    public Transform _chest;
    public Vector3 _chestVector;
    public Vector3 _leftVector;
    public Vector3 _rightVector;
    void LateUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            if(_moveBack == 0)
            {
                if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Run_Rifle"))
                {
                    _animator.Play("Run_Rifle");
                }
                _moveForward = 1;
                transform.position += transform.forward/35;
            }
        }
        if(Input.GetKey(KeyCode.A))
        {
            if(_moveRight == 0)
            {
                if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Run_Left_Rifle") && _moveForward == 0 && _moveBack == 0)
                {
                    _animator.Play("Run_Left_Rifle");
                }
                _moveLeft = 1;
                transform.position += -transform.right/35;
                _chest.localEulerAngles = _leftVector;
            }
        }
        if(Input.GetKey(KeyCode.D))
        {
            if(_moveLeft == 0)
            {
                if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Run_Right_Rifle") && _moveForward == 0 && _moveBack == 0)
                {
                    _animator.Play("Run_Right_Rifle");
                }
                _moveRight = 1;
                transform.position += transform.right/35;
                _chest.localEulerAngles = _rightVector;
            }
        }
        if(Input.GetKey(KeyCode.S))
        {
            if(_moveForward == 0)
            {
                if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Back_Run_Rifle"))
                {
                    _animator.Play("Back_Run_Rifle");
                }
                _moveBack = 1;
                transform.position += -transform.forward/35;
            }
        }

        if(Input.GetKeyUp(KeyCode.W))
        {
            _moveForward = 0;
        } 
        if(Input.GetKeyUp(KeyCode.A))
        {
            _moveLeft = 0;
        } 
        if(Input.GetKeyUp(KeyCode.D))
        {
            _moveRight = 0;
        } 
        if(Input.GetKeyUp(KeyCode.S))
        {
            _moveBack = 0;
        } 

        if(_moveForward == 0 && _moveBack == 0 && _moveLeft == 0 && _moveRight == 0)
        {
            _animator.Play("Idle");
        }
    }
}