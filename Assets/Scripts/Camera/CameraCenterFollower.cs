using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraCenterFollower : MonoBehaviour
{
    public Transform player1Transform;
    public Transform player2Transform;

    private Transform _cameraTransform;
    private Vector3 _cameraPosition;
    private float _time = 0;
    private CameraResizer _cameraResizer;

    // Start is called before the first frame update
    void Awake()
    {
        _cameraTransform = GetComponent<Transform>();
        _cameraPosition = _cameraTransform.position;
        _cameraResizer = GetComponent<CameraResizer>();
    }

    // Update is called once per frame
    void Update()
    {
        _cameraPosition = _cameraTransform.position;
        
        Vector3 centerPoint = (player1Transform.position + player2Transform.position) / 2;

        var changeY = _cameraResizer.getCameraSizeChange();

        var cameraX = _cameraPosition.x;
        var cameraY = _cameraPosition.y;
        _time += Time.deltaTime;
        _cameraTransform.localPosition = new Vector3(
            Mathf.SmoothStep(cameraX, centerPoint.x, _time),
            Mathf.SmoothStep(cameraY, changeY, _time),
            _cameraPosition.z
        );
    }
}