using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonController : PlayerController
{
    private InputAction look_action;
    public Camera cam;
    [Range(0.01f, 2f)] public float sensitivity = 1;
    public bool invert_x = false;
    public bool invert_y = false;
    [HideInInspector] public Vector2 look_input = Vector2.zero;
    [HideInInspector] public float look_speed = 60;
    [HideInInspector] public float vertical_look_angle = 0;
    [HideInInspector] public int invert_factor_x = 1;
    [HideInInspector] public int invert_factor_y = 1; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    new void Start()
    {
        //Call parent Start()
        base.Start();

        //Hide cursor on game start
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //Find reference to the input actions
        look_action = InputSystem.actions.FindAction("Look");
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();

        //Read input values for looking around
        look_input = look_action.ReadValue<Vector2>();

        //Rotate the player to look left/right
        transform.Rotate(Vector2.up, look_input.x * invert_factor_x * look_speed * sensitivity * Time.deltaTime);
        float angle = look_input.y * invert_factor_y * look_speed * sensitivity * Time.deltaTime;

        //Rotate the camera to look up/down
        vertical_look_angle -= angle;
        vertical_look_angle = Mathf.Clamp(vertical_look_angle, -90, 90);
        cam.transform.localRotation = Quaternion.Euler(vertical_look_angle, 0, 0);
    }
}
