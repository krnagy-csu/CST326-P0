using UnityEngine;

public class Rotator : MonoBehaviour
{
    public int pointValue = 1;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
