using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vector2 = UnityEngine.Vector2;

namespace Puzzle_Interactables
{
    public class Whirlpool : MonoBehaviour
    {
        [SerializeField] private Vector3 center;
        [SerializeField] private float strength;
        [SerializeField] private bool scaling = false;
        [SerializeField] private float scalingStrength = 0;
        [SerializeField] private float strengthMax = 5;
        [SerializeField] private int timesCanBeActivated = 1;
        [SerializeField] private UnityEvent hitCenter;

        private int _activated = 0;
        private Dictionary<Collider2D, float> _strengthPerObj = new Dictionary<Collider2D, float>();
        private void OnTriggerStay2D(Collider2D col)
        {
            col.transform.position = Vector3.MoveTowards(col.transform.position, 
                                        center, _strengthPerObj[col] * Time.deltaTime);
            if (col.transform.position.x == center.x && col.transform.position.y == center.y 
                && _activated < timesCanBeActivated)
            {
                hitCenter?.Invoke();
                _activated++;
            }
            else if (_strengthPerObj.ContainsKey(col) && scaling)
            {
                if(_strengthPerObj[col] < strengthMax)
                    _strengthPerObj[col] += scalingStrength;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_strengthPerObj.ContainsKey(other))
            {
                _strengthPerObj[other] = strength;
            }
            else
            {
                _strengthPerObj.Add(other,strength);
            }
        }
    }
}