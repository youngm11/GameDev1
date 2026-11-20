using UnityEngine;

public class StateIdle : FirstPersonControllerState
{
    public override void Enter(StateMachine state_machine)
    {
        //Change Color
        //fp_controller.rend.material.color = Color.darkGreen;
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
        if (fp_controller.direction != Vector2.zero)
        {
            state_machine.TransitionToState(state_machine.states[1]);
            return;
        }

        //Air State
        if (fp_controller.jump)
        {
            fp_controller.y_velocity = fp_controller.jump_impulse;
            state_machine.TransitionToState(state_machine.states[2]);
            return;
        }
    }
}
