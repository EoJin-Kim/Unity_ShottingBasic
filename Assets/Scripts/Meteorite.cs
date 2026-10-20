using UnityEngine;

public class Meteorite : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		// 운석과 충돌한 오브젝트의 태그가 "Player"이면
		if ( collision.CompareTag("Player") )
		{
			// 운석 삭제
			Destroy(gameObject);
		}
	}
}

