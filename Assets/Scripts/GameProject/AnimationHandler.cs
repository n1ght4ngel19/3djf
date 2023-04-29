using UnityEngine;
using UnityEngine.AI;

namespace GameProject {
  /// <summary>
  /// Handles setting the Animator parameters for the various types of characters.
  /// </summary>
  public class AnimationHandler : MonoBehaviour {
    public Animator OwnAnimator { get; set; }
    public bool IsMoving { get; set; }
    public bool IsRunning { get; set; }
    public bool DoAttack { get; set; }
    public bool IsAttacking { get; set; }
    public bool DoAltAttack { get; set; }
    public bool IsAltAttacking { get; set; }
    public bool DoSummon { get; set; }
    public bool IsSummoning { get; set; }
    public bool IsInterrupted { get; set; }
    public bool Die { get; set; }


    private void Awake() {
      OwnAnimator = GetComponent<Animator>();
    }

    /// <summary>
    /// Sets Animator parameters for Player.
    /// </summary>
    /// <param name="moveInput">The player's input regarding the X and Y axes.</param>
    public void SetParameters(Vector2 moveInput) {
      IsMoving = moveInput != Vector2.zero;
      OwnAnimator.SetBool(CharacterState.Move, IsMoving);
      IsRunning = Input.GetKey(KeyCode.LeftShift);
      OwnAnimator.SetBool(CharacterState.Run, IsRunning);
      DoAttack = Input.GetMouseButtonDown(0);
      OwnAnimator.SetBool(CharacterState.Attack, DoAttack);
      DoAltAttack = Input.GetMouseButtonDown(1);
      OwnAnimator.SetBool(CharacterState.AltAttack, DoAltAttack);
      DoSummon = Input.GetKeyDown(KeyCode.Q);
      OwnAnimator.SetBool(CharacterState.Summon, DoSummon);
      IsAttacking = OwnAnimator.GetCurrentAnimatorStateInfo(0).IsName(CharacterState.Attack);
      IsAltAttacking = OwnAnimator.GetCurrentAnimatorStateInfo(0).IsName(CharacterState.AltAttack);
      IsSummoning = OwnAnimator.GetCurrentAnimatorStateInfo(0).IsName(CharacterState.Summon);
      IsInterrupted = OwnAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Interrupt");
    }

    /// <summary>
    /// Sets Animator parameters for Npc's.
    /// </summary>
    /// <param name="agent">The NavMeshAgent of the Npc.</param>
    public void SetParameters(NavMeshAgent agent) {
      IsMoving = agent.velocity != Vector3.zero;
      OwnAnimator.SetBool(CharacterState.Move, IsMoving);
      IsRunning = Input.GetKey(KeyCode.LeftShift);
      OwnAnimator.SetBool(CharacterState.Run, IsRunning);
      DoAttack = Input.GetMouseButtonDown(0);
      OwnAnimator.SetBool(CharacterState.Attack, DoAttack);
      DoAltAttack = Input.GetMouseButtonDown(1);
      OwnAnimator.SetBool(CharacterState.AltAttack, DoAltAttack);
      IsAttacking = OwnAnimator.GetCurrentAnimatorStateInfo(0).IsName(CharacterState.Attack);
      IsAltAttacking = OwnAnimator.GetCurrentAnimatorStateInfo(0).IsName(CharacterState.AltAttack);
      IsInterrupted = OwnAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Interrupt");
    }
  }
}
