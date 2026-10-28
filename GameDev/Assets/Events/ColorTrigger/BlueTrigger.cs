using UnityEngine;
using UnityEngine.Events;

public class BlueTrigger : MonoBehaviour
{
    public UnityEvent<Color> SetBlue;
    public UnityEvent<Color, float, int, string> Event;
    private void OnTriggerEnter(Collider other)
    {
        SetBlue.Invoke(Color.blue);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
