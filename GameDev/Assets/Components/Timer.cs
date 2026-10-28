using UnityEngine;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour

{
    //A timer is something that keeps track of time
    // If a timer has >0 time it will  begin to ocunt down until no time remains
    // timers can be paused
    // A paused timer retains its current time value
    // A timer can be paused/unpaused by using the SetPause() function.
    // A timer will be unpasued if StartTimer() is used.
    [Tooltip("The current time on the timer. If the Timer has time, it will count down")]
    [SerializeField][Range(0f, 600f)] private float time;
    private bool is_paused = false;
    private bool has_finished = false;
    //Gets the time from the timer
    public float GetTime()
    {
        return time;
    }

    //Gets the finished state of the timer
    public bool IsFinished()
    {
        return has_finished;
    }

    //Sets the paused status of the timer
    public void SetPause(bool pause)
    {
        is_paused = pause;
    }

    //Gets the pause status of the timer
    public bool GetPause()
    {
        return (is_paused);
    }

    public void StartTimer(float t)
    {
        time = t; //Assign the time passed in
        is_paused = false;
        has_finished = false;
    }

    public void StopTimer()
    {
        has_finished = true; //The timer has finished
        time = 0; //So set its time to zero
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Start the timer if the user sets the time in the inspector
        if (time > 0)
            StartTimer(time);
    }

    // Update is called once per frame
    void Update()
    {
        //Setop the timer from running if it is paused or has finished
        if (is_paused || has_finished)
            return;

        if (time > 0) //If the timer has time on it
            time -= Time.deltaTime; // Countdown
        else //Otherwise
            StopTimer(); //Stop the timer
    }
}
