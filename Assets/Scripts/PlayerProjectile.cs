using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		// 발사체와 충돌한 오브젝트의 태그가 "Enemy"이면
		if ( collision.CompareTag("Enemy") )
		{
			// 충돌한 오브젝트 삭제 (적 캐릭터)
			Destroy(collision.gameObject);
			// 플레이어 발사체 오브젝트 삭제
			Destroy(gameObject);
		}
	}
}

