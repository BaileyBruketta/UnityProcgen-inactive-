using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{

    public Rigidbody CharRigBod;
    public GameObject ThisChar;
    public int speed;
    public GameObject gameCam;
    public float rotationSpeed;
    float rotX = 0.001F, rotY = 0.0F;
    public float mouseSensitivity = 25.0F;
    // Start is called before the first frame update
    void Start()
    {
        CharRigBod.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotation();

    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            CharRigBod.velocity = ThisChar.transform.forward * speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            CharRigBod.velocity = ThisChar.transform.right * -speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            CharRigBod.velocity = ThisChar.transform.forward * -speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            CharRigBod.velocity = ThisChar.transform.right * speed;
        }
    }

    void Rotation()
    {
        gameCam.transform.Rotate(ThisChar.transform.up, -Input.GetAxis("Mouse X") * rotationSpeed, Space.World);
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        rotX = mouseY * mouseSensitivity;
        rotY = mouseX * mouseSensitivity;
        gameCam.transform.rotation *= Quaternion.Euler(-rotX, 0, 0.0f);
    }
}
