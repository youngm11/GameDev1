using UnityEngine;

public class CubePrefab : MonoBehaviour
{
    private CubeDestroyTrigger trigger;
    private void OnDestroy()
    {
        //CubeDestroyTrigger.OnTouch -= OnDestroy;
        Destroy(this.gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Find the trigger game object and then subject to the unity event
        trigger = GameObject.Find("CubeDestroyTrigger").GetComponent<CubeDestroyTrigger>();
        trigger.OnTouch.AddListener(OnDestroy);
        // CubeDestroyTrigger.OnTouch += OnDestroy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTouch()
    {

    }
}
