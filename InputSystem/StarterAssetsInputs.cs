using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		//benim yazd���m 
		public bool Orbball;
		public bool fire;
		public bool menu;
		//public bool AttackOne;


		[Header("Movement Settings")]
		public bool analogMovement;

		//[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;


		//UI ���N YAPTI�IM G�R��LER
		
	



#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}





#endif


	




	// benim yazd���m komut orbball
	public void OrbballInput(bool newFireStateorball)
		{
			Orbball = newFireStateorball;
		}

		public void OnOrbball(InputValue value)
		{
			OrbballInput(value.isPressed);
		}

		//benim yazd���m komut projecttile

		public void FireInput(bool newFireState)
        {
           fire = newFireState;
		}

		 public void OnFire(InputValue value)
        {
         FireInput(value.isPressed);
        }


		//UI aras� ge�i�
		public void MenuInput(bool newUIState)
        {
          menu = newUIState;
        }


		public void OnMenu(InputValue value)
        {
			MenuInput(value.isPressed);
        }


		//mouse sol t�k i�in
		/*public void FireInputtwo(bool newFireState)
       {
       AttackOne = newFireState;

       }

		public void OnFiretwo(InputValue value)
       {
        FireInputtwo(value.isPressed);
        }*/



	public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}


       

    }
	
}