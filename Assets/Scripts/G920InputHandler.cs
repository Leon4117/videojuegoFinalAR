
using UnityEngine;
using UnityEngine.InputSystem;
 
public class G920InputHandler : MonoBehaviour
{
    public GameInput controls;
    private float steeringValue;
    private float throttleValue;
    private float reverseValue;
 
    void Awake()
    {
        controls = new GameInput();
    }
 
    void OnEnable()
    {
        controls.Driving.Enable();
 
        controls.Driving.Steering.performed += ctx => steeringValue = ctx.ReadValue<float>();
        controls.Driving.Steering.canceled += ctx => steeringValue = 0f;
 
        controls.Driving.Throttle.performed += ctx => throttleValue = ctx.ReadValue<float>();
        controls.Driving.Throttle.canceled += ctx => throttleValue = 0f;
 
        controls.Driving.Reversa.performed += ctx => reverseValue = ctx.ReadValue<float>();
        controls.Driving.Reversa.canceled += ctx => reverseValue = 0f;
    }
 
    void OnDisable()
    {
        controls.Driving.Disable();
    }
 
    public float GetSteeringValue() => steeringValue;
    public float GetThrottleValue() => throttleValue;
    public float GetReverseValue() => reverseValue;
}

/*using UnityEngine;
using UnityEngine.InputSystem;
 
public class G920InputHandler : MonoBehaviour
{
    public GameInput controls;
    private float steeringValue;
    private float throttleValue;
 
    void Awake()
    {
        controls = new GameInput();
    }
 
    void OnEnable()
    {
        controls.Driving.Enable();
        controls.Driving.Steering.performed += ctx => steeringValue = ctx.ReadValue<float>();
        controls.Driving.Steering.canceled += ctx => steeringValue = 0f;
 
        controls.Driving.Throttle.performed += ctx => throttleValue = ctx.ReadValue<float>();
        controls.Driving.Throttle.canceled += ctx => throttleValue = 0f;
    }
 
    void OnDisable()
    {
        controls.Driving.Disable();
    }
 
    public float GetSteeringValue()
    {
        return steeringValue;
    }
 
    public float GetThrottleValue()
    {
        return throttleValue;
    }
}*/