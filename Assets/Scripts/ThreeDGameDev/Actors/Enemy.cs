using System;
using UnityEngine;

namespace ThreeDGameDev.Actors {
  public class Enemy : Character {
    [field: SerializeField] public GameObject LockOnTarget { get; set; }
    [field: SerializeField] public bool IsLockOnTarget { get; set; }

    private void Update() {
      LockOnTarget.gameObject.SetActive(IsLockOnTarget);
    }
  }
}
