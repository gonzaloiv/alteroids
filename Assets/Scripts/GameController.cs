using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

  #region Mono Behaviour

  void OnEnable() {
    EventManager.StartListening<SpaceInput>(OnSpaceInput);
  }

  void OnDisable() {
    EventManager.StopListening<SpaceInput>(OnSpaceInput);
  }

  #endregion 

  #region Event Behaviour

  void OnSpaceInput(SpaceInput spaceInput) {
    Debug.Log("Game awakening!");
  }

  #endregion

}
