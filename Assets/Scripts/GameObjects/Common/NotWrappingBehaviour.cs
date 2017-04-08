using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class NotWrappingBehaviour : MonoBehaviour {

  #region Fields

  private Vector2 screenSize;

  #endregion

  #region Mono Behaviour

  void Awake() {
    screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
  }

  void Update() {
    if (transform.position.x > screenSize.x)
      gameObject.SetActive(false);
    if (transform.position.x < -screenSize.x)
      gameObject.SetActive(false);
    if (transform.position.y > screenSize.y)
      gameObject.SetActive(false);
    if (transform.position.y < -screenSize.y)
      gameObject.SetActive(false);
  }

  #endregion

}
