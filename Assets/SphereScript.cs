using UnityEngine;

public class SphereScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float degreesPerSecond = 30;
    void Start()
    {
        Debug.Log("Hello world!");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.Rotate(new Vector3(0, degreesPerSecond * Time.deltaTime, 0));
    }
}
