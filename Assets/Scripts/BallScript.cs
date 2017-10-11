using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class BallScript : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 10f;

    public GameObject plane;

    public GameObject spawnPoint;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < plane.transform.position.y - 10)
        {

            transform.position = spawnPoint.transform.position;

        }
    }

    private void FixedUpdate()
    {
        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        float y = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 move = new Vector3(x, 0, y);
        rb.velocity = move * speed;

        if (x != 0 && y != 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x, y) * Mathf.Rad2Deg, transform.eulerAngles.z);
        }
    }
}
