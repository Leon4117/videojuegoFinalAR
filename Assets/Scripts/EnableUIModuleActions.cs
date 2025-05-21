using UnityEngine;
using UnityEngine.InputSystem;

public class EnableUIModuleActions : MonoBehaviour
{
    public InputActionAsset inputActions;

    void OnEnable()
    {
        inputActions.Enable(); // Esto activa todos los mapas del asset
    }

    void OnDisable()
    {
        inputActions.Disable();
    }
}
