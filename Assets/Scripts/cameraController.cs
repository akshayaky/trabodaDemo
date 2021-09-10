using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
	public Transform player;
	public float mouseSensitivity = 150f;

	private float yRotation;
	private float xRotation = 0f;

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked; 
	}

	float Clamp(float val, float min, float max)
	{
		var temp = val;
		if(val > min && val < max)
		{
			if(Mathf.Abs(min - val) > Mathf.Abs(max - val))
				val = max; 
			else
				val = min;
		}
		// else if(val > max)
		// {
		// 	val = max;
		// }
		// Debug.Log(val);
		// Debug.Log("              " + temp);
		return val;
	}
	void Update()
	{
		Vector3 rot = transform.localEulerAngles;
		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
		
		rot.y += mouseX;
		rot.x -= mouseY;
		// Debug.Log(rot.y);
		rot.x = Clamp(rot.x, 80, 290);
		// rot.y = Clamp(rot.y, 0, 190);
		

		// transform.Rotate(new Vector3(-1 * mouseY, 0, 0));	
		transform.localEulerAngles = rot;
		if(mouseX != 0) {
			// transform.Rotate(Vector3.up * mouseX);
			player.Rotate(Vector3.up  * mouseX);
			// transform.Rotate(Vector3.right * -1 * transform.localRotation.x);		
		}
		yRotation = transform.rotation.y;
		// transform.rotation = new Vector3(x, y, 0f);
	}

    void FixedUpdate()
    {
        transform.position = player.position;
        var temp = player.localEulerAngles;
        temp.y = yRotation;
        // player.localEulerAngles = temp;
        // player.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z));
    	// player.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles);
    }	
}
