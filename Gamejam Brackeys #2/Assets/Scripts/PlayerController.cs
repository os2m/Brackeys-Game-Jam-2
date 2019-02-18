using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public float movementSpeed = .15f;
    public float mouseSensitivity = 5f;
    public Camera playerCam;
    private Vector3 direction;
    public float cameraOffset = 1.1f;

    // Start is called before the first frame update
    void Start()
    {
        playerCam = Camera.main;
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        playerCam.transform.position = transform.position + playerCam.transform.up * cameraOffset;

        // WASD
        direction.x = Input.GetAxis("Horizontal") * movementSpeed;
        direction.z = Input.GetAxis("Vertical") * movementSpeed;
        direction = transform.TransformDirection(direction);

        transform.Rotate(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0);
        playerCam.transform.parent = transform;
        playerCam.transform.Rotate(-Input.GetAxis("Mouse Y") * mouseSensitivity, 0, 0);
        transform.Translate(Input.GetAxis("Horizontal") * movementSpeed, 0, Input.GetAxis("Vertical") * movementSpeed);
    }
}
