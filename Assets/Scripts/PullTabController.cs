using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PullTabController : MonoBehaviour
{
    [SerializeField] private Transform parentTransform;

    private float _offsetx;

    private bool _isBeingHeld;
    private Vector3 _mousePos;

    public float minX;
    public float maxX;

    private float minLimX = -2.5f;
    private float maxLimX = 2.5f;
    
    private float startCoord;

    public bool vertical;

    public bool pullable;
    
    private void Start()
    {
        // startCoord = vertical ? parentTransform.position.y : parentTransform.position.x;
        minLimX = minX;
        maxLimX = maxX;

        pullable = true;
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && pullable)
        {
            _mousePos = Input.mousePosition;
            _mousePos = Camera.main.ScreenToWorldPoint(_mousePos);

            _offsetx = vertical ? _mousePos.y - parentTransform.position.y : _mousePos.x - parentTransform.position.x;
            
            _isBeingHeld = true;
        }
    }

    public IEnumerator Expose()
    {
        pullable = false;
        var targetPosition = vertical ? 
            new Vector3( parentTransform.position.x  ,minLimX, parentTransform.position.z)
            :
            new Vector3( minLimX  ,parentTransform.position.y, parentTransform.position.z);
        Tween prereq = parentTransform.DOMove(targetPosition, 1.0f);
        yield return prereq.WaitForCompletion();
        pullable = true;
    }

    public IEnumerator Conceal()
    {
        pullable = false;
        var targetPosition = vertical ? 
            new Vector3( parentTransform.position.x  ,maxLimX, parentTransform.position.z)
            :
            new Vector3( maxLimX  ,parentTransform.position.y, parentTransform.position.z);
        Tween prereq = parentTransform.DOMove(targetPosition, 1.0f);
        yield return prereq.WaitForCompletion();
        pullable = true;
    }

    private void OnMouseUp()
    {
        _isBeingHeld = false;
    }

    private void Update()
    {
        if (_isBeingHeld == true)
        {  
            _mousePos = Input.mousePosition;
            _mousePos = Camera.main.ScreenToWorldPoint(_mousePos);
            parentTransform.position = vertical ? 
                new Vector3( parentTransform.position.x  ,Mathf.Clamp(_mousePos.y - _offsetx, minLimX, maxLimX), parentTransform.position.z)
                :
                new Vector3( Mathf.Clamp(_mousePos.x - _offsetx, minLimX, maxLimX)  ,parentTransform.position.y, parentTransform.position.z);
        }
    }
}
