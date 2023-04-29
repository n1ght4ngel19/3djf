using UnityEngine;
using UnityEngine.AI;

namespace GameProject {
  /// <summary>
  /// A character that is not controlled by the player.
  /// </summary>
  public class Npc : Character {
    private NavMeshAgent Agent { get; set; }
    private Character Target { get; set; }


    protected override void Awake() {
      base.Awake();
      Agent = GetComponent<NavMeshAgent>();
    }

    private void Start() {}

    private void Update() {
      if (Target is not null && Vector3.Distance(Target.transform.position, transform.position) < 15f) {
        Agent.SetDestination(Target.transform.position);
      }
    }
  }
}
