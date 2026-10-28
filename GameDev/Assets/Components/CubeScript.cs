using UnityEngine;

public class CubeScript : MonoBehaviour
{

    private MeshRenderer mesh_renderer;
    private Timer timer;

    private float change_color_time = 2f;

    private void ChangeColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        mesh_renderer.material.color = new Color(r, g, b);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mesh_renderer = GetComponent<MeshRenderer>();
        timer = GetComponent<Timer>();

        timer.StartTimer(change_color_time);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            timer.SetPause(true);
        if (Input.GetKeyDown(KeyCode.X)) ;
        timer.SetPause(false);

        if (timer.IsFinished())
        {
            ChangeColor();
            timer.StartTimer(change_color_time);
        }
    }
}
