using UnityEngine;

namespace ThreeDGameDev.Actors {
  public class Player : Character {
    [field: SerializeField] private Transform OwnCameraTransform { get; set; }
    [field: SerializeField] public float Speed { get; set; }
    [field: SerializeField] public float TurnSpeed { get; set; }
    [field: SerializeField] public bool IsInvulnerable { get; set; }
    private float HorizontalInput { get; set; }
    private float VerticalInput { get; set; }


    private void Update() {
      HorizontalInput = Input.GetAxis("Horizontal");
      VerticalInput = Input.GetAxis("Vertical");

      OwnAnimator.SetBool(PlayerState.IsMoving, !HorizontalInput.Equals(0) || !VerticalInput.Equals(0));
      OwnAnimator.SetBool(PlayerState.IsRunning, Input.GetKey(KeyCode.LeftShift));
      OwnAnimator.SetBool(PlayerState.IsAttacking, Input.GetMouseButtonDown(0));
      OwnAnimator.SetBool(PlayerState.IsBlocking, Input.GetMouseButton(1));
      OwnAnimator.SetBool(PlayerState.IsRolling, Input.GetKey(KeyCode.Space));
      // IsInvulnerable = OwnAnimator.GetCurrentAnimatorStateInfo(0).IsName("Rolling");


      Vector3 moveDirection = new Vector3(HorizontalInput, 0, VerticalInput);
      float inputMagnitude = Mathf.Clamp01(moveDirection.magnitude) * Speed;

      // Rotate the character considering current camera rotation as well
      moveDirection = Quaternion.AngleAxis(OwnCameraTransform.rotation.eulerAngles.y, Vector3.up) * moveDirection;
      moveDirection.Normalize();

      Vector3 velocity = moveDirection * inputMagnitude;

      if (!moveDirection.Equals(Vector3.zero)) {
        Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, TurnSpeed * Time.deltaTime);
      }

      // if (OwnAnimator.GetBool(PlayerState.IsRolling)) {
      //   transform.Translate(velocity * (10 * (Speed * Time.deltaTime)), Space.World);
      // }

      transform.Translate(velocity * (Speed * Time.deltaTime), Space.World);
    }

    private void OnApplicationFocus(bool hasFocus) {
      Cursor.lockState = hasFocus ? CursorLockMode.Locked : CursorLockMode.None;
    }

    private void Attack(Character character) {}
  }
}
