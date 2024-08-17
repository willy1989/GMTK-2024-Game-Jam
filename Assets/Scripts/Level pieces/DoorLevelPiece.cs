using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLevelPiece : MonoBehaviour
{
    [SerializeField] private HingeJoint2D hingeJoint;

    public void ToggleDoor(bool onOff)
    {
        // Get the current motor settings
        JointMotor2D motor = hingeJoint.motor;

        if (onOff == true)
        {
            motor.motorSpeed = 100f;
        }

        else
        {
            motor.motorSpeed = -100f;
        }

        // Assign the modified motor back to the hinge joint
        hingeJoint.motor = motor;
    }
}
