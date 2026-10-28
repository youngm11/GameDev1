using UnityEngine;

public class ColorCube : MonoBehaviour
{
    public void ChangeColor(Color col)
    {
        GetComponent<MeshRenderer>().material.color = col;
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
