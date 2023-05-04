using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameProject {
  public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    public Player Player { get; set; }
    public List<Footman> Footmen { get; set; }
    public List<Beholder> Beholders { get; set; }
    public List<ChestMonster> ChestMonsters { get; set; }
    public List<Grunt> Grunts { get; set; }

    private void Awake() {
      if (Instance is not null && Instance != this) {
        Destroy(this);

        return;
      }

      Instance = this;
      Player = FindObjectOfType<Player>();
      Footmen = FindObjectsOfType<Footman>().ToList();
      Beholders = FindObjectsOfType<Beholder>().ToList();
      ChestMonsters = FindObjectsOfType<ChestMonster>().ToList();
      Grunts = FindObjectsOfType<Grunt>().ToList();
    }

    private void Start() {}

    private void OnApplicationFocus(bool hasFocus) {
      Cursor.lockState = hasFocus ? CursorLockMode.Locked : CursorLockMode.None;
    }

    public void GameOver() {}
  }
}
