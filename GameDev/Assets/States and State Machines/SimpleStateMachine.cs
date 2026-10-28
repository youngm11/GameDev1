using UnityEngine;

public class SimpleStateMachine : MonoBehaviour
{
    //Components
    private PlayerController player_controller;
    
    //States
    enum States
    {
        Idle,
        Ground,
        Air,
    }
    private States current_state = States.Idle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player_controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //State Machine
        switch(current_state)
        {
            case States.Idle:
                IdleState();
                break;

            case States.Ground:
                GroundState();
                break;

            case States.Air:
                AirState();
                break;
        }
    }

    private void IdleState()
    {
        //Change Color
        player_controller.rend.material.color = Color.darkGreen;

        #region State Changes
        //Ground States
        if(player_controller.direction != Vector2.zero)
        {
            current_state = States.Ground;
            return;
        }
        #endregion
    }

    private void GroundState()
    {
        //Change Color
        player_controller.rend.material.color = Color.green;

        //Accelerate
        player_controller.xz_velocity += player_controller.direction 
                                        * player_controller.acceleration 
                                        * Time.fixedDeltaTime;
        player_controller.xz_velocity = Vector2.ClampMagnitude(player_controller.xz_velocity,
                                                               player_controller.speed);

        //Friction
        if(player_controller.direction == Vector2.zero)
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

        #region State Changes
        //Idle States
        if (player_controller.controller.velocity == Vector3.zero)
        {
            current_state = States.Idle;
            return;
        }
        #endregion
    }

    private void AirState()
    {

    }
}
