using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSmBehaviour : MonoBehaviour {

  #region Fields

  [SerializeField] private int SPEED = 2;
  private GameObject player;
  private Vector2 playerPosition;
  private Vector3 direction;

  #endregion

  #region Mono Behaviour

  void Update() {
    if(player != null)
      transform.position = Vector2.MoveTowards(transform.position, playerPosition, SPEED * Time.deltaTime);
  }

  #endregion

  #region Public Behaviour

  public void Initialize(GameObject player) {
    this.player = player;
    this.playerPosition = player.transform.position;
  }

  #endregion

  #region Private Behaviour

  private Quaternion FocusOnPlayer(Vector3 playerPosition) {
    Vector3 dir = playerPosition - transform.position;
    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    return Quaternion.AngleAxis(angle + -90, Vector3.forward);
  }

  #endregion
  	
}
