using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class StateIdle : PlayerState
{
    public override void Enter(StateMachine state_machine)
    {
        //Change Color
        player_controller.rend.material.color = Color.darkGreen;
    }
    public override void Exit(StateMachine state_machine)
    {

    }
    public override void StateUpdate(StateMachine state_machine)
    {

    }
    public override void StateFixedUpdate(StateMachine state_machine)
    {
        //Ground States
        if (player_controller.direction != Vector2.zero)
        {
            state_machine.TransitionToState(state_machine.states[1]);
            return;
        }

        //Air State
        if (player_controller.jump)
        {
            player_controller.y_velocity = player_controller.jump_impulse;
            state_machine.TransitionToState(state_machine.states[2]);
            return;
        }
    }
}
