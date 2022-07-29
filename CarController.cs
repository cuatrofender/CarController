using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    [SerializeField] public WheelCollider[] wheelColliders;
    [SerializeField] public Transform[] wheelMeshes;
    [SerializeField] public float speed;
    [SerializeField] public float turnAngle;

    Quaternion quaternion;
    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float _speed = Input.GetAxis("Vertical") * speed;
        float currTurnAngle = Input.GetAxis("Horizontal") * turnAngle;

        foreach(WheelCollider _wc in wheelColliders) {
            _wc.motorTorque = _speed;

            _wc.GetWorldPose(out position, out quaternion);
            _wc.transform.GetChild(0).transform.position = position;
            _wc.transform.GetChild(0).transform.rotation = quaternion;
        }

        wheelColliders[0].steerAngle = currTurnAngle;
        wheelColliders[1].steerAngle = currTurnAngle;

    }
}
