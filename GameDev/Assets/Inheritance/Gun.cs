using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public Camera cam;
    public Transform shoot_point;
    public float range = 25; //In meters
    public float time_between_shots = 0.5f; //In seconds
    Timer shoot_timer;
    InputAction shoot_action;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Get Components
        shoot_timer = GetComponent<Timer>();

        //Find reference to the input actions
        shoot_action = InputSystem.actions.FindAction("Attack");
    }
    
    protected virtual void Shoot()
    {
        //Function to be overwritten by child scripts
        Debug.Log("Shoot.");
    }

    protected bool is_automatic()
    {
        if(shoot_action.IsPressed() && shoot_timer.IsFinished())
        {
            shoot_timer.StartTimer(time_between_shots);
            return true;
        }
        else
        {
            return false;
        }
    }

    protected bool is_manual()
    {
        if (shoot_action.WasPressedThisFrame() && shoot_timer.IsFinished())
        {
            shoot_timer.StartTimer(time_between_shots);
            return true;
        }
        else
        {
            return false;
        }
    }
}
