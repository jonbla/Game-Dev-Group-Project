using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageBump : MonoBehaviour
{
	private Vector3 myStart;
	public float smoothTime = 0.6f;

	private float velocityX = 0f;
    private float velocityY = 0f;
    private float velocityZ = 0f;

    bool isDisabled = false;
    // Start is called before the first frame update
    void Start()
    {
        myStart = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDisabled) { return; }
	    var tempX = Mathf.SmoothDamp(transform.position.x, myStart.x, ref velocityX, smoothTime);
	    var tempY = Mathf.SmoothDamp(transform.position.y, myStart.y, ref velocityY, smoothTime);
	    var tempZ = Mathf.SmoothDamp(transform.position.z, myStart.z, ref velocityZ, smoothTime);
	    transform.position = new Vector3(tempX, tempY, tempZ);
    }
    public void bumpUp(){
    	transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
    }
    public void bumpDown(){
    	transform.position = new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z);
    }

    public void Disable()
    {
        isDisabled = true;
    }
}
