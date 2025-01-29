using UnityEngine;

public class WallScript : MonoBehaviour
{
    public GameObject player;
    public GameObject other;
    public int pointThreshold;
    private PlayerController playerController;
    public Animator myAnimator;
    // Update is called once per frame
    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }
    private void FixedUpdate()
    {
        if (gameObject.activeSelf == true && playerController.score >= pointThreshold)
        {
            myAnimator.SetBool("drop",true);
            other.SetActive(true);
        }
    }
}
