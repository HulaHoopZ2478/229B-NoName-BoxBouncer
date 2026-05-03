using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
	public Transform targetPosition;
	public float speed = 2f;
	private bool shouldMove = false;

	public void ActivatePlatform()
	{
		shouldMove = true;
	}

	void Update()
	{
		if (shouldMove)
		{
			transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);
			if (Vector3.Distance(transform.position, targetPosition.position) < 0.01f)
			{
				shouldMove = false;
			}
		}
	}
}
