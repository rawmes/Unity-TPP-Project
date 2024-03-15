
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;


public class MouseLockHandler : MonoBehaviour
{
    [SerializeField]
    private InputActionReference mouseLockKey;

    private CinemachineInputProvider inputProvider;

    bool mouseIsLocked = true;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private void OnEnable()
    {
        mouseLockKey.action.Enable();
    }
    private void OnDisable()
    {
        mouseLockKey.action.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        inputProvider = GetComponent<CinemachineInputProvider>();
        if (mouseIsLocked) { Cursor.lockState = CursorLockMode.Locked; }
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseLockKey.action.triggered)
        {
            if (mouseIsLocked) 
            {
                Cursor.lockState = CursorLockMode.None; mouseIsLocked = false;
                inputProvider.enabled = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked; mouseIsLocked = true;
                inputProvider.enabled=true;
            }
        }

        if (!mouseIsLocked)
        {
            if (Input.GetMouseButtonDown(1))
            {
                inputProvider.enabled = true;
            }
            if (Input.GetMouseButtonUp(1))
            {
                inputProvider.enabled = false;
            }
        }
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    void OnMouseExit()
    {
        // Pass 'null' to the texture parameter to use the default system cursor.
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
