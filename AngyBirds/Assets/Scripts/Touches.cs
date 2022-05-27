using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touches : MonoBehaviour
{
    public RectTransform _image;

    private Vector3 _firstTouch;
    private Vector3 _lastTouch;

    public Vector3 Force { get; private set; }

    public event Action<Vector3> ApplyForce;

    void Update()
    {
        if (Input.GetMouseButton(0))
            ShowPower(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            _firstTouch = Input.mousePosition;
            _image.position = _firstTouch;
            CubeVisibling(true);
        }

        else if (Input.GetMouseButtonUp(0))
        {
            _lastTouch = Input.mousePosition;
            CalculateForce();
            ApplyForce(Force);
            ImageToDefault();
            CubeVisibling(false);
        }
    }

    public void CalculateForce()
    {
        Force = _firstTouch - _lastTouch;
    }

    public void ShowPower(Vector3 current)
    {
        var vec = _firstTouch - current;

        _image.localScale = new Vector3(vec.x, 10) / 100;
    }

    private void ImageToDefault()
    {
        _image.localScale = Vector3.one;
    }

    private void CubeVisibling(bool isVisible)
    {
        if (isVisible)
            _image.gameObject.SetActive(true);
        else
            _image.gameObject.SetActive(false);
    }
}
