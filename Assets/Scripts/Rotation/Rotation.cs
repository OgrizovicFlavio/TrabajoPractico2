using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] private float rotationAngle = 10f;
    [SerializeField] private KeyCode rotateRight = KeyCode.E;
    [SerializeField] private KeyCode rotateLeft = KeyCode.Q;

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        if (Input.GetKeyDown(rotateRight))
        {
            transform.Rotate(0, 0, rotationAngle);
        }

        if (Input.GetKeyDown(rotateLeft))
        {
            transform.Rotate(0, 0, -rotationAngle);
        }
    }

    public void SetRotationAngle(float newAngle)
    {
        if (newAngle < 0)
        {
            return;
        }
        rotationAngle = newAngle;
        if (rotationAngle >= 360f)
            rotationAngle -= 360f;
    }

    public float GetRotationAngle()
    {
        return rotationAngle;
    }
}
