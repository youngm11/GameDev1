using UnityEngine;
using UnityEngine.Events;

public class YellowTrigger : MonoBehaviour
{
    public UnityEvent<Color> SetYellow;
    public UnityEvent<Color, float, int, string> Event;
    private void OnTriggerEnter(Collider other)
    {
        SetYellow.Invoke(Color.yellow);
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
