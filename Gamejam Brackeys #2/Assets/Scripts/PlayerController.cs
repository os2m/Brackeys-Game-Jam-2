/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public float movementSpeed = .2f;
    public float mouseSensitivity = 5f;
    public Camera playerCam;
    private Vector3 direction;
    public float cameraOffsetUp = 1.1f;
    public float cameraOffsetForward = -2f;
    private Vector3 spawnPoint;
    private AudioSource audioSource;

    [SyncVar] public int hasFinished;

    //public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        playerCam = Camera.main;
        spawnPoint = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.green;
    }

    void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        else
        {
            this.gameObject.name = "Player (Local)";
        }


        playerCam.transform.position = transform.position + (playerCam.transform.up * cameraOffsetUp) + playerCam.transform.forward * cameraOffsetForward;

        // WASD
        direction.x = Input.GetAxis("Horizontal") * movementSpeed;
        direction.z = Input.GetAxis("Vertical") * movementSpeed;
        direction = transform.TransformDirection(direction);

        float speedProof = direction.x + direction.z + direction.x;
        if (speedProof < 0)
            speedProof = speedProof * -1;
        //anim.SetFloat("running", speedProof);


        transform.Rotate(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0);
        playerCam.transform.parent = transform;
        playerCam.transform.Rotate(-Input.GetAxis("Mouse Y") * mouseSensitivity, 0, 0);
        transform.Translate(Input.GetAxis("Horizontal") * movementSpeed, 0, Input.GetAxis("Vertical") * movementSpeed);
    }

    public void Respawn()
    {
        transform.position = spawnPoint;
        audioSource.pitch = Random.Range(1.0f, 3.0f);
        Debug.Log(audioSource.pitch);
        audioSource.Play(0);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Respawn"))
            spawnPoint = transform.position;

        else if (other.CompareTag("Finish")) {
            hasFinished = 1;
            RpcSyncVars(hasFinished);
        }
    }

    [ClientRpc]
    void RpcSyncVars(int varToSync)
    {
        hasFinished = varToSync;
    }
}
*/

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

    /* NEW */
    public int hasFinished = 0;
    private Vector3 spawnPoint;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        playerCam = Camera.main;

        spawnPoint = transform.position;
        audioSource = GetComponent<AudioSource>();

        if (!isLocalPlayer)
        {
            audioSource.volume = 0;
        }
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

    public void Respawn()
    {
        transform.position = spawnPoint;
        audioSource.pitch = Random.Range(1.0f, 3.0f);
        //Debug.Log(audioSource.pitch);
        audioSource.Play(0);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Respawn"))
            spawnPoint = transform.position;

        else if (other.CompareTag("Finish"))
        {
            hasFinished = 1;
        }
    }
}
