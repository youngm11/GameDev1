using UnityEngine;

public class FirstPersonControllerState : State
{
    protected FirstPersonController fp_controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fp_controller = GameObject.Find("Player").GetComponent<FirstPersonController>();
    }

}
