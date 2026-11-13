using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerState : State

{
    protected PlayerController player_controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player_controller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
