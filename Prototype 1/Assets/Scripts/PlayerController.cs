using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //Private Variable so  scope is within the class
    [SerializeField] float speed;
    [SerializeField] float horsePower = 20000;
    [SerializeField] float rpm;
    [SerializeField] List<WheelCollider> allWheels;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    private int wheelsOnGround;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Inputs
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            //Run the vehicle forward/backward
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            playerRb.AddRelativeForce(Vector3.forward * verticalInput * horsePower);

            //Rotate the vehicle left/right
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 2.237f);
            speedometerText.SetText("Speed: " + speed + " mph");

            rpm = Mathf.Rad2Deg * transform.InverseTransformDirection(playerRb.angularVelocity).x;
            rpmText.SetText("RPM: " + rpm);
        }
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
