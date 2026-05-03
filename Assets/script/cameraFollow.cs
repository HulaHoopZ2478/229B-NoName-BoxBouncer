using UnityEngine;

public class cameraFollow : MonoBehaviour
{
	private Vector3 offset = new Vector3(0, 0, -10f);
	private float smoothtime = 0.25f;
	private Vector3 velocity = Vector3.zero;

	[SerializeField] private Transform target;

	// --- เพิ่มตัวแปรใหม่ตรงนี้ ---
	[Header("Camera Boundaries")]
	[SerializeField] private Vector2 minBounds; // จุดต่ำสุดซ้ายล่าง (x, y)
	[SerializeField] private Vector2 maxBounds; // จุดสูงสุดขวายกบน (x, y)

	private void Update()
	{
		// 1. คำนวณตำแหน่งที่กล้องควรไปตามปกติ
		Vector3 targetPosition = target.position + offset;

		// 2. ทำการ Clamp (ล็อค) ตำแหน่ง X และ Y ไม่ให้เกินค่าที่เรากำหนด
		float clampedX = Mathf.Clamp(targetPosition.x, minBounds.x, maxBounds.x);
		float clampedY = Mathf.Clamp(targetPosition.y, minBounds.y, maxBounds.y);

		// 3. สร้างตำแหน่งใหม่ที่ถูกล็อคแล้ว (ค่า Z ต้องเท่ากับ offset เดิม)
		Vector3 finalPosition = new Vector3(clampedX, clampedY, offset.z);

		// 4. สั่งให้กล้องขยับแบบสมูทไปที่ตำแหน่งที่ถูกล็อคแล้ว
		transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref velocity, smoothtime);
	}
}
