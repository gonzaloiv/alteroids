using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSmBehaviour : MonoBehaviour {

  #region Fields

  [SerializeField] private int SPEED = 2;
  private GameObject player;
  private Vector3 direction;

  #endregion

  #region Mono Behaviour

  void Update() {
    if(player != null)
      transform.position = Vector2.MoveTowards(transform.position, player.transform.position, SPEED * Time.deltaTime);
  }

  #endregion

  #region Public Behaviour

  public void Initialize(GameObject player) {
    this.player = player;
  }

  #endregion
  	
}
