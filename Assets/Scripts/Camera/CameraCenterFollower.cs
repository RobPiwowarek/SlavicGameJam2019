using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraCenterFollower : MonoBehaviour
{
    public Transform player1Transform;
    public Transform player2Transform;
    public Transform cameraTransform;
    
    private Vector3 _cameraPosition;
    private float _time = 0;

    // Start is called before the first frame update
    void Start()
    {
        _cameraPosition = cameraTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _cameraPosition = cameraTransform.position;
        Vector3 centerPoint = (player1Transform.position + player2Transform.position) / 2;
        var cameraX = _cameraPosition.x;
        var cameraY = _cameraPosition.y;
        _time += Time.deltaTime;
        cameraTransform.localPosition = new Vector3(
            Mathf.SmoothStep(cameraX, centerPoint.x, _time),
            Mathf.SmoothStep(cameraY, centerPoint.y, _time),
            _cameraPosition.z
        );
    }
}