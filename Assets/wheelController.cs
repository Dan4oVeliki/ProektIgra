using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    [SerializeField] WheelCollider wheelCollider;
    private float HorizontalInput;
    private float VerticalInput;
    public float MotorSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wheelCollider.motorTorque = HorizontalInput * MotorSpeed;
    }
    void GetInput()
    {
        HorizontalInput = Input.GetAxis(HORIZONTAL);
        VerticalInput = Input.GetAxis(VERTICAL);
    }
}
