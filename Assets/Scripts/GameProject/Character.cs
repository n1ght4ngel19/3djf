using UnityEngine;

namespace GameProject {
  /// <summary>
  /// The base class for the various types of characters in the game.
  /// </summary>
  public class Character : MonoBehaviour {
    public Health Health { get; set; }
    public AnimationHandler AnimationHandler { get; set; }


    protected virtual void Awake() {
      Health = GetComponent<Health>();
      AnimationHandler = gameObject.AddComponent<AnimationHandler>();
    }
  }
}
