using UnityEngine;

namespace ThreeDGameDev.Actors {
  public class Player : Character {
    [field: SerializeField] private Transform OwnCameraTransform { get; set; }
    [field: SerializeField] private Animator OwnAnimator { get; set; }
    [field: SerializeField] public float Speed { get; set; }
    [field: SerializeField] public float TurnSpeed { get; set; }
    private float HorizontalInput { get; set; }
    private float VerticalInput { get; set; }


    private void Start() {
      OwnAnimator = GetComponent<Animator>();
      OwnAnimator.Play("Idle");
    }

    private void Update() {
      HorizontalInput = Input.GetAxis("Horizontal");
      VerticalInput = Input.GetAxis("Vertical");

      OwnAnimator.SetBool(PlayerState.IsMoving, !HorizontalInput.Equals(0) || !VerticalInput.Equals(0));

      OwnAnimator.SetBool(PlayerState.IsRunning, Input.GetKey(KeyCode.LeftShift));
      OwnAnimator.SetBool(PlayerState.IsAttacking, Input.GetMouseButtonDown(0));
      OwnAnimator.SetBool(PlayerState.IsBlocking, Input.GetMouseButton(1));

      if (OwnAnimator.GetBool(PlayerState.IsBlocking) || OwnAnimator.GetBool(PlayerState.IsAttacking)) {
        return;
      }

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

      transform.Translate(velocity * (Speed * Time.deltaTime), Space.World);
    }

    private void OnApplicationFocus(bool hasFocus) {
      Cursor.lockState = hasFocus ? CursorLockMode.Locked : CursorLockMode.None;
    }

    private void Attack(Character character) {}
  }
}
