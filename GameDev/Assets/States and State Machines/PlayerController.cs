using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Input
    private InputAction move_action;
    private InputAction jump_action;

    //Components
    [HideInInspector] public CharacterController controller;
    [HideInInspector] public MeshRenderer rend;

    //Movement Variables
    public float speed = 5;
    [HideInInspector] public Vector2 direction = Vector2.zero;
    [HideInInspector] public Vector2 xz_velocity = Vector2.zero;
    [HideInInspector] public float y_velocity = 0f;
    [HideInInspector] public Vector3 velocity = Vector3.zero;

    //Accelerations
    public float acceleration = 30f;
    public float friction = 25f;
    public float gravity = 9.81f; //Must be positive.

    //Forces
    public float jump_impulse = 10f;

    //Jumping
    [HideInInspector] public bool jump = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Get Components.
        controller = GetComponent<CharacterController>();
        rend = GetComponent<MeshRenderer>();

        //Get Inputs
        move_action = InputSystem.actions.FindAction("Move");
        jump_action = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        //Read Input
        direction = move_action.ReadValue<Vector2>();
        jump = jump_action.IsPressed();
    }
}
