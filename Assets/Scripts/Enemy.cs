using UnityEngine;

public class Enemy : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		// 적 캐릭터와 충돌한 오브젝트의 태그가 "Player"이면
		if ( collision.CompareTag("Player") )
		{
			// 적 캐릭터 삭제
			Destroy(gameObject);
		}
	}
}

