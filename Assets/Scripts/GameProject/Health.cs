﻿using UnityEngine;
using UnityEngine.UI;

namespace GameProject {
  public class Health : MonoBehaviour {
    [field: SerializeField] public float MaxHealth { get; set; }
    [field: SerializeField] public float CurrentHealth { get; set; }
    private Slider Healthbar { get; set; }


    private void Awake() {
      Healthbar = GetComponentInChildren<Slider>();
    }

    private void Start() {
      Healthbar.maxValue = MaxHealth;
      CurrentHealth = MaxHealth;
    }

    private void Update() {
      Healthbar.transform.rotation = Camera.main.transform.rotation;
      Healthbar.value = CurrentHealth;
    }
  }
}
