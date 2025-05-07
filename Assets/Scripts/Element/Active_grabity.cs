using UnityEngine;

public class Active_grabity : MonoBehaviour
{
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    public void OnGrab()
    {
        if (rb.useGravity == false)
            rb.useGravity=true;
        if (rb.isKinematic == true)
            rb.isKinematic=false;
    }
    
}
