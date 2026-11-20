using UnityEngine;

public class StateAir : FirstPersonControllerState
{
    public override void Enter(StateMachine state_machine)
    {
        //Change Color
        //fp_controller.rend.material.color = Color.blue;
    }
    public override void Exit(StateMachine state_machine)
    {

    }
    public override void StateUpdate(StateMachine state_machine)
    {

    }
    public override void StateFixedUpdate(StateMachine state_machine)
    {
        //Accelerate
        Vector3 accel_vec = fp_controller.acceleration * (transform.right * fp_controller.direction.x + transform.forward * fp_controller.direction.y);

        fp_controller.xz_velocity += new Vector2(accel_vec.x, accel_vec.z);

        fp_controller.xz_velocity = Vector2.ClampMagnitude(fp_controller.xz_velocity,
                                                               fp_controller.speed);
        //Gravity
        fp_controller.y_velocity -= fp_controller.gravity * Time.fixedDeltaTime;

        //Construct Velocity
        fp_controller.velocity = new Vector3(fp_controller.xz_velocity.x,
                                                 fp_controller.y_velocity,
                                                 fp_controller.xz_velocity.y);

        //Move
        fp_controller.controller.Move(fp_controller.velocity * Time.fixedDeltaTime);

        //Sync velocities after the move
        fp_controller.velocity = fp_controller.controller.velocity;
        fp_controller.xz_velocity = new Vector3(fp_controller.controller.velocity.x, fp_controller.controller.velocity.z);
        fp_controller.y_velocity = fp_controller.controller.velocity.y;


        #region State Changes
        if (fp_controller.controller.isGrounded)
        {
            if (fp_controller.xz_velocity == Vector2.zero)
                state_machine.TransitionToState(state_machine.states[0]);
            else
                state_machine.TransitionToState(state_machine.states[1]);
        }
        #endregion
    }
}

