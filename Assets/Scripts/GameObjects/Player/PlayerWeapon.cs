using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerWeapon : MonoBehaviour {

  #region Mono Behaviour

  private int SHOT_AMOUNT = 20;

  [SerializeField] private GameObject shotPrefab;
  private GameObjectPool shots;

  #endregion

  #region Mono Behaviour

  void Awake() {
    shots = new GameObjectPool("ShotPool", shotPrefab, 10, transform.parent); 
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
    if (shots.ActiveObjects < SHOT_AMOUNT) { 
      GameObject shot = shots.PopObject();
      shot.transform.position = transform.position + transform.up / 3;
      shot.transform.rotation = transform.rotation;
      shot.SetActive(true);
    }
  }

  #endregion

}
