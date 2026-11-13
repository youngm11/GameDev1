using UnityEditor.Rendering;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private State current_state;
    public State[] states;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        current_state = states[0];
        current_state.Enter(this);
    }

    // Update is called once per frame
    void Update()
    {
        current_state.StateUpdate(this);
    }
    private void FixedUpdate()
    {
        current_state.StateFixedUpdate(this);
    }
    public void TransitionToState(State new_state)
    {
        current_state.Exit(this);
        current_state = new_state;
        current_state.Enter(this);
    }
}
