using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraResizer : MonoBehaviour
{
    public float minSize = 5.0f;
    public float maxSize = 15f;
    public float epsilon = 0.1f;
    public Transform player1Transform;
    public Transform player2Transform;

    private Camera _camera;
    private float _time = 0;
    
    private const float EpsilonExpandX = 8f;
    private const float EpsilonCollapseX = 10f;
    private const float EpsilonExpandY = 6f;
    private const float EpsilonCollapseY = 8f;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        var distanceX = Math.Abs(player1Transform.position.x - player2Transform.position.x);
        var distanceY = Math.Abs(player1Transform.position.y - player2Transform.position.y);
        var cameraSize = _camera.orthographicSize;
        var viewPointWidth = _camera.aspect * 2f * cameraSize;
        var viewPointHeight = 2f * cameraSize;
        if (distanceX > viewPointWidth - EpsilonExpandX)
        {
            if (cameraSize > maxSize) return;
            _time += Time.deltaTime;
            _camera.orthographicSize = Mathf.SmoothStep(_camera.orthographicSize, cameraSize + epsilon, _time);
        }
        else if (distanceX < viewPointWidth - EpsilonCollapseX && viewPointHeight - distanceY > EpsilonCollapseY)
        {
            if (cameraSize < minSize) return;
            _time += Time.deltaTime;
            _camera.orthographicSize = Mathf.SmoothStep(_camera.orthographicSize, cameraSize - epsilon, _time);
        }
        else if (distanceY > viewPointHeight - EpsilonExpandY)
        {
            if (cameraSize > maxSize) return;
            _time += Time.deltaTime;
            _camera.orthographicSize = Mathf.SmoothStep(_camera.orthographicSize, cameraSize + epsilon, _time);
        }
        else if (distanceY < viewPointHeight - EpsilonCollapseY && viewPointWidth - distanceX > EpsilonCollapseX)
        {
            if (cameraSize < minSize) return;
            _time += Time.deltaTime;
            _camera.orthographicSize = Mathf.SmoothStep(_camera.orthographicSize, cameraSize - epsilon, _time);
        }
    }

    public float getCameraSizeChange()
    {
        return _camera.orthographicSize - minSize;
    }
}