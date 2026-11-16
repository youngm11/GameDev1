using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class StateGround : PlayerState
{
    public override void Enter(StateMachine state_machine)
    {
        //Change Color
        player_controller.rend.material.color = Color.green;
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

        //Friction
        if (player_controller.direction == Vector2.zero)
        {
            player_controller.xz_velocity = Vector2.MoveTowards(player_controller.xz_velocity,
                                            Vector2.zero,
                                            player_controller.friction * Time.fixedDeltaTime);
        }


        //Construct Velocity
        player_controller.velocity = new Vector3(player_controller.xz_velocity.x,
                                                 -player_controller.gravity,
                                                 player_controller.xz_velocity.y);

        //Move
        player_controller.controller.Move(player_controller.velocity * Time.fixedDeltaTime);

        //Sync velocities after the move
        player_controller.velocity = player_controller.controller.velocity;
        player_controller.xz_velocity = new Vector3(player_controller.controller.velocity.x, player_controller.controller.velocity.z);


        #region State Changes
        //Idle States
        if (player_controller.controller.velocity == Vector3.zero)
        {
            if (player_controller.direction == Vector2.zero)
            {
                state_machine.TransitionToState(state_machine.states[0]);
                return;
            }

        }
        //Air State
        //Pressing the space bar
        if (player_controller.jump && player_controller.controller.isGrounded)
        {
            player_controller.y_velocity = player_controller.jump_impulse;
            state_machine.TransitionToState(state_machine.states[2]);
            return;
        }

        //Walking off of a ledge
        if (!player_controller.controller.isGrounded)
        {
            state_machine.TransitionToState(state_machine.states[2]);
            return;
        }
        #endregion

    }
}
