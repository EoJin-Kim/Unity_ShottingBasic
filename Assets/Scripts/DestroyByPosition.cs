using UnityEngine;

public class DestroyByPosition : MonoBehaviour
{
	[SerializeField]
	private	StageData	stageData;

	// 화면 밖 일정 범위를 벗어났을 때 삭제하기 위한 가중치 값
	private	float		destroyWeight = 2;

	private void LateUpdate()
	{
		if ( transform.position.y < stageData.LimitMin.y - destroyWeight ||
			 transform.position.y > stageData.LimitMax.y + destroyWeight ||
			 transform.position.x < stageData.LimitMin.x - destroyWeight ||
			 transform.position.x > stageData.LimitMax.x + destroyWeight )
		{
			Destroy(gameObject);
		}
	}
}

