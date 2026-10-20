using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private	StageData	stageData;
	[SerializeField]
	private	Key			keyAttack = Key.Space;

	private	Movement2D	movement2D;
	private	Weapon		weapon;

	private void Awake()
	{
		movement2D	= GetComponent<Movement2D>();
		weapon		= GetComponent<Weapon>();
	}

	private void Update()
	{
		Keyboard keyboard = Keyboard.current;
		if ( keyboard == null ) return;

		float x = 0;
		float y = 0;

		if ( keyboard.leftArrowKey.isPressed  || keyboard.aKey.isPressed ) x -= 1;
		if ( keyboard.rightArrowKey.isPressed || keyboard.dKey.isPressed ) x += 1;
		if ( keyboard.downArrowKey.isPressed  || keyboard.sKey.isPressed ) y -= 1;
		if ( keyboard.upArrowKey.isPressed    || keyboard.wKey.isPressed ) y += 1;

		movement2D.MoveTo(new Vector3(x, y, 0));

		if ( keyboard[keyAttack].isPressed )
		{
			weapon.WeaponAction();
		}
	}

	private void LateUpdate()
	{
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
										 Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));
	}
}

