using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMove : MonoBehaviour
{
    [SerializeField] private float sensitivity = 10;

    void Update()
    {
        var direction = new Vector3(
            Input.GetAxis("Horizontal") *  sensitivity,
            0,
            Input.GetAxis("Vertical") * sensitivity
        );

        transform.position += direction * Time.deltaTime;
    }
}
