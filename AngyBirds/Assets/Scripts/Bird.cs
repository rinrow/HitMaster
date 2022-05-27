using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private Touches touches;
    private Rigidbody _rigidbody;

    void Start()
    {
        touches.ApplyForce += Force;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Force(Vector3 vector)
    {
        _rigidbody.AddForce(vector);
    }
}
