using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PlayerWeapon : MonoBehaviour {

  #region Mono Behaviour

  private int SHOT_AMOUNT = 20;
  private float SHOT_SPEED = .175f;

  [SerializeField] private GameObject shotPrefab;
  [SerializeField] private GameObject playerShots;
  private GameObjectPool shots;
  private float shotTime;

  #endregion

  #region Mono Behaviour

  void Awake() {
    shotTime = Time.time;
    shots = new GameObjectPool("PlayerShots", shotPrefab, 10, playerShots.transform); 
  }

  void OnEnable() {
    EventManager.StartListening<SpaceInput>(OnSpaceInput);
  }

  void OnDisable() {
    EventManager.StopListening<SpaceInput>(OnSpaceInput);
  }

  #endregion

  #region Event Behaviour

  void OnSpaceInput(SpaceInput spaceInput) {
    if (Time.time > shotTime + SHOT_SPEED && shots.ActiveObjects < SHOT_AMOUNT) {
      shotTime = Time.time;
      GameObject shot = shots.PopObject();
      shot.transform.position = transform.position + transform.up / 3;
      shot.transform.rotation = transform.rotation;
      shot.SetActive(true);
      EventManager.TriggerEvent(new PlayerShotEvent());
    }
  }

  #endregion

}
