using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class StateAir : PlayerState
{
    public override void Enter(StateMachine state_machine)
    {
        //Change Color
        //player_controller.rend.material.color = Color.blue;
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
        player_controller.xz_velocity += player_controller.direction
                                        * player_controller.acceleration
                                        * Time.fixedDeltaTime;
        player_controller.xz_velocity = Vector2.ClampMagnitude(player_controller.xz_velocity,
                                                               player_controller.speed);
        //Gravity
        player_controller.y_velocity -= player_controller.gravity * Time.fixedDeltaTime;

        //Construct Velocity
        player_controller.velocity = new Vector3(player_controller.xz_velocity.x,
                                                 player_controller.y_velocity,
                                                 player_controller.xz_velocity.y);

        //Move
        player_controller.controller.Move(player_controller.velocity * Time.fixedDeltaTime);

        //Sync velocities after the move
        player_controller.velocity = player_controller.controller.velocity;
        player_controller.xz_velocity = new Vector3(player_controller.controller.velocity.x, player_controller.controller.velocity.z);
        player_controller.y_velocity = player_controller.controller.velocity.y;


        #region State Changes
        if (player_controller.controller.isGrounded)
        {
            if (player_controller.xz_velocity == Vector2.zero)
                state_machine.TransitionToState(state_machine.states[0]);
            else
                state_machine.TransitionToState(state_machine.states[1]);
        }
        #endregion
    }
}

