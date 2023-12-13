using System;
using UnityEngine;

public static class Models
{
    [Serializable]
    public class PlayerSettingsModel
    {
        [Header("View Settings")]
        public float ViewXSensitivity;
        public float ViewYSensitivity;

        public bool ViewXInverted;
        public bool ViewYInverted;
        
        public float viewClampYMin;
        public float viewClampYMax;

        [Header("Movement")] 
        public float WalkingForwardSpeed;
        public float WalkingBackwardSpeed;
        public float WalkingStrafeSpeed;
        
        [Header("Jumping")] 
        public float JumpingForce;
        public float JumpingHeight;
        public float JumpingFalloff;
    }
}
