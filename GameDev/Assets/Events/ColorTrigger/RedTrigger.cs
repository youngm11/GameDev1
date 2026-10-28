using UnityEngine;
using UnityEngine.Events;

public class RedTrigger : MonoBehaviour
{
    public UnityEvent<Color> SetRed;
    public UnityEvent<Color, float, int, string> Event;
    private void OnTriggerEnter(Collider other)
    {
        SetRed.Invoke(Color.red);
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
