
using UnityEngine;
using System.Collections;

public class SnakeBody : MonoBehaviour
{

	private Transform head;
	[Range(0.0f, 1.0f)]
	public float overTime = 0.2f;

	private int myOrder;
	private Vector3 movementVelocity;

	void Start()
	{
		head = GameObject.FindGameObjectWithTag("SnakeHead").gameObject.transform;
		for (int i = 0; i < head.GetComponent<SnakeHead>().bodyParts.Count; i++)
		{
			if (gameObject == head.GetComponent<SnakeHead>().bodyParts[i].gameObject)
			{
				myOrder = i;
			}
		}
	}

	void FixedUpdate()
	{
		if (myOrder == 0)
		{
			transform.position = Vector3.SmoothDamp(transform.position, head.position, ref movementVelocity, overTime);
			transform.LookAt(head.transform.position);
		}
		else
		{
			transform.position = Vector3.SmoothDamp(transform.position, head.GetComponent<SnakeHead>().bodyParts[myOrder - 1].position, ref movementVelocity, overTime);
			transform.LookAt(head.transform.position);
		}
	}
}
