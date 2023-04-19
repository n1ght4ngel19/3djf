using UnityEngine;

namespace ThreeDGameDev {
  public class Weapon : MonoBehaviour {
    [field: SerializeField] public WeaponName Name { get; set; }

    private void Start() {
      transform.localPosition = WeaponSocketOffset.LocationOffset[Name];
      // transform.rotation.x = WeaponSocketOffset.RotationOffset[Name].x;
      // transform.rotation.y = WeaponSocketOffset.RotationOffset[Name].y;
      // transform.rotation.z = WeaponSocketOffset.RotationOffset[Name].z;
      transform.Rotate(WeaponSocketOffset.RotationOffset[Name]);
    }
  }
}
