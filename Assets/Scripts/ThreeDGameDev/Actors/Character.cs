using UnityEngine;

namespace ThreeDGameDev.Actors {
  public class Character : MonoBehaviour {
    [field: SerializeField] public int Health { get; set; }
    [field: SerializeField] protected Animator OwnAnimator { get; set; }


    protected virtual void Start() {
      OwnAnimator = GetComponent<Animator>();
      OwnAnimator.Play("Idle");
    }
  }
}
