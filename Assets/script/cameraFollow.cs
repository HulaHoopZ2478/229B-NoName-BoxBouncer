using UnityEngine;

public class cameraFollow : MonoBehaviour
{
	private Vector3 offset = new Vector3(0, 0, -10f);
	private float smoothtime = 0.25f;
	private Vector3 velocity = Vector3.zero;

	[SerializeField] private Transform target;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	private void Update()
	{
		Vector3 targetPosition = target.position + offset;
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothtime);
	}
}
