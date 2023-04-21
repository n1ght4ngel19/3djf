using System.Collections.Generic;
using UnityEngine;

namespace ThreeDGameDev {
  public static class WeaponSocketOffset {
    public static readonly Dictionary<WeaponName, Vector3> LocationOffset = new Dictionary<WeaponName, Vector3> {
      { WeaponName.DoubleShortsword, new Vector3(0.125f, 0.03f, 0.25f) },
      { WeaponName.VikingShield, new Vector3(0f, -0.07f, -0.015f) },
      { WeaponName.Shortsword, new Vector3(0.185f, 0f, 0.25f) },
      { WeaponName.BlackSword, new Vector3(-0.2f, 0.32f, -0.1f) },
    };

    public static readonly Dictionary<WeaponName, Vector3> RotationOffset = new Dictionary<WeaponName, Vector3> {
      { WeaponName.DoubleShortsword, new Vector3(-10f, 24f, -30.5f) },
      { WeaponName.VikingShield, new Vector3(178f, -8f, -103f) },
      { WeaponName.Shortsword, new Vector3(-10f, 24f, -30.5f) },
      { WeaponName.BlackSword, new Vector3(-128f, 55f, -108f) },
    };
  }
}
