using UnityEngine;

public class triggerbuTriggerButton : MonoBehaviour
{
	public MovingPlatform platform;
	private bool isActivated = false;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("bullet") && !isActivated)
		{
			isActivated = true;
			Debug.Log("Button Shot!");
			platform.ActivatePlatform(); 
			GetComponent<SpriteRenderer>().color = Color.green;
		}
	}
}
