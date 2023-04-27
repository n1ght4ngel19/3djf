using UnityEngine;

namespace GameProject {
  /// <summary>
  /// The character the player is controlling.
  /// </summary>
  public class Player : Character {
    private Vector2 MoveInput { get; set; }
    private Transform CameraTransform { get; set; }
    private float Speed { get; set; }
    private const float WalkSpeed = 3f;
    private const float RunSpeed = 4f;
    private const float TurnSpeed = 360f;


    protected override void Awake() {
      base.Awake();
      CameraTransform = Camera.main.transform;
      Speed = WalkSpeed;
    }

    private void Start() {}

    private void Update() {
      MoveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
      AnimationHandler.SetParameters(MoveInput);
      Speed = AnimationHandler.IsRunning ? RunSpeed : WalkSpeed;


      if (AnimationHandler.DoAttack) {
        // Instantiate(Shot, transform.position + new Vector3(-0.5f, 1.8f, 1.6f), Quaternion.identity);
      }

      // foreach (Footman footman in GameManager.Instance.Footmen) {
      //   if (Vector3.Distance(footman.transform.position, transform.position) < 20f) {
      //     moveDirection = new Vector3(footman.transform.position.x - transform.position.x, 0, footman.transform.position.y - transform.position.y);
      //   } else {
      //   }
      // }

      Vector3 moveDirection = new Vector3(MoveInput.x, 0, MoveInput.y);
      float inputMagnitude = Mathf.Clamp01(moveDirection.magnitude) * Speed;

      // Rotate the character considering current camera rotation as well
      // Todo: Above comment is wrong
      moveDirection = Quaternion.AngleAxis(CameraTransform.rotation.eulerAngles.y, Vector3.up) * moveDirection;
      moveDirection.Normalize();

      Vector3 velocity = moveDirection * inputMagnitude;
      Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

      if (AnimationHandler.IsMoving && !AnimationHandler.IsInterrupted) {
        MoveSelfWith(velocity);
        RotateSelfTowards(toRotation);
      }
    }

    private void MoveSelfWith(Vector3 velocity) {
      transform.Translate(velocity * (Speed * Time.deltaTime), Space.World);
    }

    private void RotateSelfTowards(Quaternion rotation) {
      transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, TurnSpeed * Time.deltaTime);
    }
  }
}
