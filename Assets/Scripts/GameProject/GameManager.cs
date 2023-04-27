using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameProject {
  public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    public Player Player { get; set; }
    public List<Footman> Footmen { get; set; }

    private void Awake() {
      if (Instance is not null && Instance != this) {
        Destroy(this);

        return;
      }

      Instance = this;
    }

    private void Start() {
      Player = FindObjectOfType<Player>();
      Footmen = FindObjectsOfType<Footman>().ToList();
    }

    private void OnApplicationFocus(bool hasFocus) {
      Cursor.lockState = hasFocus ? CursorLockMode.Locked : CursorLockMode.None;
    }

    public void GameOver() {}
  }
}
