using System.Collections;
using UnityEngine;

public class FadeEffect : MonoBehaviour
{
	private	SpriteRenderer	spriteRenderer;
	private	float			fadeTime = 0.1f;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();

		StartCoroutine(nameof(TwinkleLoop));
	}

	private IEnumerator TwinkleLoop()
	{
		while ( true )
		{
			// Alpha 값을 1에서 0으로 : Fade Out
			yield return StartCoroutine(OnFade(1, 0));

			// Alpha 값을 0에서 1로 : Fade In
			yield return StartCoroutine(OnFade(0, 1));
		}
	}

	private IEnumerator OnFade(float start, float end)
	{
		float percent = 0;

		// fadeTime 시간동안 while() 반복문 실행
		while ( percent < 1 )
		{
			percent += Time.deltaTime / fadeTime;

			// 유니티의 클래스에 설정되어 있는 spriteRenderer.color, transform.position 등은 프로퍼티로
			// spriteRenderer.color.a = 1.0f; 과 같이 설정이 불가능하다.
			// spriteRenderer.color = new Color(spriteRenderer.color.r, .., .., 1.0f); 과 같이 설정해야 한다.
			
			// 또는 아래와 같이 별도의 Color 변수를 만들어 변수 값을 변경하고, spriteRenderer.color에 변수 값을 저장한다.
			Color color = spriteRenderer.color;
			color.a = Mathf.Lerp(start, end, percent);
			spriteRenderer.color = color;

			yield return null;
		}
	}
}

