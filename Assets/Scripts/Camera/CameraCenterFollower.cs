using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraCenterFollower : MonoBehaviour
{
    [SerializeField] private float YcameraCenterOffset;
    [SerializeField] private float minOffset = 3.5f;
    [SerializeField] private float maxOffset = 13.5f;
    
    public Transform player1Transform;
    public Transform player2Transform;

    private Transform _cameraTransform;
    private Vector3 _cameraPosition;
    private float _time = 0;

    // Start is called before the first frame update
    void Awake()
    {
        _cameraTransform = GetComponent<Transform>();
        _cameraPosition = _cameraTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _cameraPosition = _cameraTransform.position;
        
        Vector3 centerPoint = (player1Transform.position + player2Transform.position) / 2;

        YcameraCenterOffset = (float)Math.Round((this.GetComponent<CameraResizer>().getCameraSizePercent() * (maxOffset - minOffset)) +
                             minOffset, 2);
        
        
        //YcameraCenterOffset = (float)Math.Ceiling(centerPoint.y -this._cameraTransform.GetComponent<Camera>().ScreenToWorldPoint(UnityEngine.Vector3.zero).y);
        //Debug.Log(centerPoint.y + " " + this._cameraTransform.GetComponent<Camera>().ScreenToWorldPoint(UnityEngine.Vector3.zero).y);
        centerPoint.y += YcameraCenterOffset;
        
        var cameraX = _cameraPosition.x;
        var cameraY = _cameraPosition.y;
        _time += Time.deltaTime;
        _cameraTransform.localPosition = new Vector3(
            Mathf.SmoothStep(cameraX, centerPoint.x, _time),
            Mathf.SmoothStep(cameraY, centerPoint.y, _time),
            _cameraPosition.z
        );
    }
}