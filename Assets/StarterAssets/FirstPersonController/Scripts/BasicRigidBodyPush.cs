using System;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class BasicRigidBodyPush : MonoBehaviour
{
	public LayerMask pushLayers;
	public bool canPush;
	[Range(0.5f, 5f)] public float strength = 1.1f;
	bool isOnTheRope = false;
    private CharacterController _controller;

    private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (canPush) PushRigidBodies(hit);
	}
    private void Start()
    {
        //_controller = GetComponent<CharacterController>();

    }

    private void Update()
    {
		//if(isOnTheRope)
		//{
		//          transform.Translate(Vector3.up * Time.deltaTime + Vector3.up, Space.World);
		//      }
		if (isOnTheRope)
		{
			//_controller.Move(Vector3.up);	
		}
    }

    private void PushRigidBodies(ControllerColliderHit hit)
	{
		// https://docs.unity3d.com/ScriptReference/CharacterController.OnControllerColliderHit.html

		// make sure we hit a non kinematic rigidbody
		Rigidbody body = hit.collider.attachedRigidbody;
		if (body == null || body.isKinematic) return;

		// make sure we only push desired layer(s)
		var bodyLayerMask = 1 << body.gameObject.layer;
		if ((bodyLayerMask & pushLayers.value) == 0) return;

		// We dont want to push objects below us
		if (hit.moveDirection.y < -0.3f) return;

		// Calculate push direction from move direction, horizontal motion only
		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0.0f, hit.moveDirection.z);

		// Apply the push and take strength into account
		body.AddForce(pushDir * strength, ForceMode.Impulse);
	}

    private void OnTriggerEnter(Collider other)
    {
		
		Debug.Log("You touch the rope!!!!");
		//transform.Translate(Vector3.up,Space.World);
		isOnTheRope = true;
    }
}