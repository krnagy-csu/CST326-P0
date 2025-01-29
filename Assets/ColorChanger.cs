using UnityEngine;
using TMPro;

public class ColorChanger : MonoBehaviour
{
    private TMP_Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.color = new Color((Mathf.Sin(Time.fixedTime * 3)),Mathf.Sin((Time.fixedTime * 3 + (2*Mathf.PI)/3)+1),Mathf.Sin((Time.fixedTime*3 + (4 * Mathf.PI) / 3) + 1));
    }
}
