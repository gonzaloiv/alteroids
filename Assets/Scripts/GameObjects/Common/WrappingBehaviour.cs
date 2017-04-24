using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrappingBehaviour : MonoBehaviour {

  #region Fields

  private Vector2 screenSize;

  #endregion

  #region Mono Behaviour

  void Awake() {
    screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
  }

  void FixedUpdate() {
    if (transform.position.x > screenSize.x)
      transform.position = new Vector2(-screenSize.x, transform.position.y);
    if (transform.position.x < -screenSize.x)
      transform.position = new Vector2(screenSize.x, transform.position.y);
    if (transform.position.y > screenSize.y)
      transform.position = new Vector2(transform.position.x, -screenSize.y);
    if (transform.position.y < -screenSize.y)
      transform.position = new Vector2(transform.position.x, screenSize.y);
  }

  #endregion

}
