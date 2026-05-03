using UnityEngine;
using UnityEngine.InputSystem;

public class projectile : MonoBehaviour
{
	[SerializeField] private Transform shootPoint;
	[SerializeField] private GameObject target;
	[SerializeField] private GameObject bulletPrefab;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	//void Start(){...}
	// Update is called once per frame
	void Update()
	{
		// 1. ทำให้เป้า (Target) วิ่งตามเมาส์ตลอดเวลา (อยู่นอก if)
		Vector2 screenPos = Mouse.current.position.ReadValue();
		// แปลงจากพิกัดหน้าจอเป็นพิกัดในโลกเกม (Z ต้องไม่เป็น 0 สำหรับ Camera)
		Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, 10f));
		target.transform.position = new Vector2(worldPos.x, worldPos.y);

		// 2. ตรวจสอบการคลิกเพื่อยิงกระสุน
		if (Mouse.current.leftButton.wasPressedThisFrame)
		{
			// คำนวณแรงและยิงกระสุน
			Vector2 projectileVelocity = CalculateProjectileVelocity(shootPoint.position, target.transform.position, 1f);
			GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
			// ใช้คำสั่งตามเวอร์ชัน Unity 6 ที่คุณใช้ในรูป
			bullet.GetComponent<Rigidbody2D>().linearVelocity = projectileVelocity;
			Destroy(bullet, 3f);
		}
		Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float time)
		{
			Vector2 direction = target - origin;
			return new Vector2(
				direction.x / time,
				(direction.y / time) + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time
				);
		}
	}
}