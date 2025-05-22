using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private InputActionAsset _inputActions; // Asigna tu Input Actions Asset (ej: GameInput)
    [SerializeField] private string _actionMapName = "Game"; // Nombre del Action Map

    // Acciones (configuradas en el Input Actions Asset)
    private InputAction _navigate;
    private InputAction _submitA;
    private InputAction _cancelB;
    private InputAction _options;
    private InputAction _clutch;
    private InputAction _y;
    private InputAction _x;

    // Variables para almacenar inputs
    private Vector2 _moveInput;
    private bool _isSubmitPressed;
    private bool _isCancelPressed;
    private bool _isOptionPressed;
    private bool _isYPressed;
    private bool _isXPressed;

    private void Awake()
    {
        // Inicializar el sistema de input
        InitializeInput();
    }

    private void InitializeInput()
    {
        // Crear un PlayerInput dinámico si no existe
        var playerInput = GetComponent<PlayerInput>();
        if (playerInput == null)
        {
            playerInput = gameObject.AddComponent<PlayerInput>();
            playerInput.actions = _inputActions;
        }

        // Obtener referencias a las acciones
        _navigate = _inputActions.FindActionMap(_actionMapName).FindAction("Navigate Cruceta");
        _submitA = _inputActions.FindActionMap(_actionMapName).FindAction("Submit A");
        _cancelB = _inputActions.FindActionMap(_actionMapName).FindAction("Cancel B");
        _options = _inputActions.FindActionMap(_actionMapName).FindAction("Pause Options");
        _y = _inputActions.FindActionMap(_actionMapName).FindAction("Nitro Y");
        _x = _inputActions.FindActionMap(_actionMapName).FindAction("X");

        // Suscribir eventos
        _navigate.performed += ctx => _moveInput = ctx.ReadValue<Vector2>();
        _navigate.canceled += ctx => _moveInput = Vector2.zero;

        _submitA.performed += ctx => _isSubmitPressed = true;
        _submitA.canceled += ctx => _isSubmitPressed = false;

        /*_cancelB.performed += ctx => _isCancelPressed = true;
        _cancelB.canceled += ctx => _isCancelPressed = false;*/
        _cancelB.performed += ctx => OnExitPressed();

        /*_options.performed += ctx => _isOptionPressed = true;
        _options.canceled += ctx => _isOptionPressed = false;*/

        _y.performed += ctx => _isYPressed = true;
        _y.canceled += ctx => _isYPressed = false;

        _x.performed += ctx => _isXPressed = true;
        _x.canceled += ctx => _isXPressed = false;

        _options.performed += ctx => OnPausePressed();
    }

    private void OnEnable()
    {
        // Activar todas las acciones
        _navigate?.Enable();
        _submitA?.Enable();
        _cancelB?.Enable();
        _options?.Enable();
        _y?.Enable();
        _x?.Enable();
    }

    private void OnDisable()
    {
        // Desactivar acciones para evitar memory leaks
        _navigate?.Disable();
        _submitA?.Disable();
        _cancelB?.Disable();
        _options?.Disable();
        _y?.Disable();
        _x?.Disable();
    }

    // Llamado desde Update() en otro script (ej: PlayerMovement)
    public Vector2 GetMoveInput() => _moveInput;

    // Llamado cuando se presiona el botón de pausa
    private void OnPausePressed()
    {
        // Obtener la referencia al MenuPause (si no está asignada)
        MenuPause pauseMenu = FindObjectOfType<MenuPause>();
        if (pauseMenu != null)
        { 
           pauseMenu.Pause();
        }
        else
        {
            Debug.LogWarning("No se encontró el script MenuPause en la escena.");
        }
    }

    private void OnExitPressed()
    {
        // Obtener la referencia al MenuPause (si no está asignada)
        MenuPause pauseMenu = FindObjectOfType<MenuPause>();
        MenuSeleccion menuSeleccion = FindObjectOfType<MenuSeleccion>();
        MenuSeleccion3D menuSeleccion3D = FindObjectOfType<MenuSeleccion3D>();
        if (pauseMenu != null)
        {
            if (pauseMenu.gamePause)
            {
                pauseMenu.Quit();
            }
        }
        else
        {
            if (menuSeleccion)
            {
                menuSeleccion.Back();
            }
            else
            {
                if (menuSeleccion3D)
                {
                    menuSeleccion3D.Back();
                }
                else
                {
                    Debug.LogWarning("No se encontró el script MenuSeleccion3D ni MenuSeleccion ni MenuPause en la escena.");
                }
            }
        }
    }
}