using System.Collections.Generic;
using UnityEngine;

namespace ThreeDGameDev {
  public static class WeaponSocketOffset {
    public static readonly Dictionary<WeaponName, Vector3> LocationOffset = new Dictionary<WeaponName, Vector3> {
      { WeaponName.DoubleShortsword, new Vector3(0.125f, 0.03f, 0.25f) },
      { WeaponName.VikingShield, new Vector3(0.1f, -0.01f, 0f) },
      { WeaponName.Shortsword, new Vector3(0.185f, 0f, 0.25f) },
    };

    public static readonly Dictionary<WeaponName, Vector3> RotationOffset = new Dictionary<WeaponName, Vector3> {
      { WeaponName.DoubleShortsword, new Vector3(-10f, 24f, -30.5f) },
      { WeaponName.VikingShield, new Vector3(100f, 90f, 90f) },
      { WeaponName.Shortsword, new Vector3(-10f, 24f, -30.5f) },
    };
  }
}
