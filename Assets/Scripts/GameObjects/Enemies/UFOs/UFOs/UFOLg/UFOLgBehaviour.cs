using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOLgBehaviour : MonoBehaviour {

  #region Fields

  [SerializeField] private int SPEED = 2;
  private Vector2 direction;
  private Vector2 screenSize;

  #endregion

  #region Mono Behaviour

  void Awake() {
    screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
  }

  void OnEnable() {
    direction = UFOLgDirection();
  }

  void Update() {
    transform.position = (Vector2) transform.position + direction * SPEED * Time.deltaTime;
  }

  #endregion

  #region Private Behaviour

  private Vector3 UFOLgDirection() {
    if (transform.position.x < -screenSize.x)
      return new Vector2(1, Random.Range(-screenSize.y, screenSize.y));
    else if (transform.position.x > screenSize.x)
      return new Vector2(-1, Random.Range(-screenSize.y, screenSize.y));
    else if (transform.position.y < -screenSize.y)
      return new Vector2(Random.Range(-screenSize.x, screenSize.x), 1);
    else
      return new Vector2(Random.Range(-screenSize.x, screenSize.x), -1);
  }

  #endregion
	
}
