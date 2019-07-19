using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Health health;
    private Vector3 _localScale;
    private Vector3 _originalScale;

    // Start is called before the first frame update
    void Start()
    {
        var scale = transform.localScale;
        _localScale = scale;
        _originalScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        if (health.IsDead)
            _localScale.x = 0;
        else
        {
            _localScale.x = health.healthPoints / health.maxHealthPoints;
            transform.localScale = _localScale;
        }
        
    }
}
