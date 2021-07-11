using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    Vector2 _newVector;
    public float _border;
    void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.name == "Field" )
        {
            _newVector = transform.position;
            if(_newVector.x <= Spawn._minVector2.x + _border || _newVector.x >= Spawn._maxVector2.x - _border)
            {
                _newVector.x = -_newVector.x;
            }
            if(_newVector.y <= Spawn._minVector2.y + _border  || _newVector.y >= Spawn._maxVector2.y - _border)
            {
                _newVector.y = -_newVector.y;
            }
            transform.position = _newVector;
        }
    }
}