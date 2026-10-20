using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField]
	private	StageData	stageData;			// 적 생성을 위한 스테이지 크기 정보
	[SerializeField]
	private	GameObject	enemyPrefab;		// 복제해서 생성할 적 캐릭터 프리팹
	[SerializeField]
	private	float		spawnCycleTime;		// 생성 주기

	private void Awake()
	{
		// StartCoroutine("Process"); 코드와 동일
		// 문자열로 호출하면 오타로 인해 오류가 발생할 수 있기 때문에 nameof() 연산자 이용
		StartCoroutine(nameof(Process));
	}

	private IEnumerator Process()
	{
		while ( true )
		{
			// 적 캐릭터 생성
			SpawnEnemy();

			// spawnCycleTime 시간동안 대기
			yield return new WaitForSeconds(spawnCycleTime);
		}
	}

	private void SpawnEnemy()
	{
		// 적 캐릭터가 생성되는 x 위치는 스테이지 크기 범위 내에서 임의의 값을 선택
		float x = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
		// 적 캐릭터 생성 (y 위치는 스테이지 상단 위치 + 1)
		Instantiate(enemyPrefab, new Vector3(x, stageData.LimitMax.y + 1, 0), Quaternion.identity);
	}
}

