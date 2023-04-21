using System.Linq;
using UnityEngine;

namespace ThreeDGameDev.Actors {
  public class Player : Character {
    [field: SerializeField] private Transform OwnCameraTransform { get; set; }
    [field: SerializeField] public float Speed { get; set; }
    [field: SerializeField] public float TurnSpeed { get; set; }
    [field: SerializeField] public bool IsInvulnerable { get; set; }
    private float HorizontalInput { get; set; }
    private float VerticalInput { get; set; }
    private const float WalkSpeed = 1.5f;
    private const float RunSpeed = 2f;


    private void Update() {
      HorizontalInput = Input.GetAxis("Horizontal");
      VerticalInput = Input.GetAxis("Vertical");

      OwnAnimator.SetBool(PlayerState.Move, !HorizontalInput.Equals(0) || !VerticalInput.Equals(0));
      OwnAnimator.SetBool(PlayerState.Run, Input.GetKey(KeyCode.LeftShift));
      OwnAnimator.SetBool(PlayerState.Attack, Input.GetMouseButtonDown(0));
      OwnAnimator.SetBool(PlayerState.Block, Input.GetMouseButton(1));
      OwnAnimator.SetBool(PlayerState.Parry, Input.GetKey(KeyCode.Space));

      if (Input.GetKeyDown(KeyCode.F)) {
        LockOn(FindObjectsOfType<Enemy>().First());
      }
      // IsInvulnerable = OwnAnimator.GetCurrentAnimatorStateInfo(0).IsName("Rolling");


      // OwnAnimator.SetBool("Move", !HorizontalInput.Equals(0) || !VerticalInput.Equals(0));
      // OwnAnimator.SetBool("Run", Input.GetKey(KeyCode.LeftShift));
      // OwnAnimator.SetBool("Move", !HorizontalInput.Equals(0) || !VerticalInput.Equals(0));

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

      Speed = OwnAnimator.GetBool(PlayerState.Run) ? RunSpeed : WalkSpeed;

      if (OwnAnimator.GetBool(PlayerState.Move) && !OwnAnimator.GetBool(PlayerState.Block) &&
        !OwnAnimator.GetCurrentAnimatorStateInfo(0).IsName(PlayerState.Attack) &&
        !OwnAnimator.GetBool(PlayerState.Parry)) {
        transform.Translate(velocity * (Speed * Time.deltaTime), Space.World);
      }
    }

    private void OnApplicationFocus(bool hasFocus) {
      Cursor.lockState = hasFocus ? CursorLockMode.Locked : CursorLockMode.None;
    }

    private void Attack(Character character) {}

    public void LockOn(Enemy target) {
      target.IsLockOnTarget = true;

      foreach (Enemy enemy in FindObjectsOfType<Enemy>().Where(enemy => !enemy.Equals(target))) {
        enemy.IsLockOnTarget = false;
      }
    }
  }
}
