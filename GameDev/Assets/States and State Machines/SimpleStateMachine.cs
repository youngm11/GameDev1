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

        //Air State
        if (player_controller.jump)
        {
            player_controller.y_velocity = player_controller.jump_impulse;
            current_state = States.Air;
            return;
        }


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

        //Sync velocities after the move
        player_controller.velocity = player_controller.controller.velocity;
        player_controller.xz_velocity = new Vector3(player_controller.controller.velocity.x, player_controller.controller.velocity.z);


        #region State Changes
        //Idle States
        if (player_controller.controller.velocity == Vector3.zero)
        {
            if (player_controller.direction == Vector2.zero)
            {
                current_state = States.Idle;
                return;
            }
            
        }
        //Air State
        //Pressing the space bar
        if (player_controller.jump && player_controller.controller.isGrounded)
        {
            player_controller.y_velocity = player_controller.jump_impulse;
            current_state = States.Air;
            return;
        }

        //Walking off of a ledge
        if (!player_controller.controller.isGrounded)
        {
            current_state = States.Air;
            return;
        }
        #endregion
    }

    private void AirState()
    {
        //Change Color
        player_controller.rend.material.color = Color.blue;

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
                current_state = States.Idle;
            else
                current_state = States.Ground;
        }
        #endregion
    }
}
