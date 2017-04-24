using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorBehaviour : MonoBehaviour {

  #region Fields

  private Rigidbody2D rb;
  private Vector2 screenSize;

  #endregion

  #region Mono Behaviour

  void Awake() {
    rb = GetComponent<Rigidbody2D>();
    screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
  }

  void Update() {

    if (transform.position.x > screenSize.x) {
      transform.position = new Vector2(screenSize.x, -transform.position.y);
      transform.Rotate(new Vector3(0, 0, 180));
      rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y, 0);
    }

    if (transform.position.x < -screenSize.x) {
      transform.position = new Vector2(-screenSize.x, -transform.position.y);
      transform.Rotate(new Vector3(0, 0, 180));
      rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y, 0);
    }

    if (transform.position.y > screenSize.y) {
      transform.position = new Vector2(-transform.position.x, screenSize.y);
      transform.Rotate(new Vector3(0, 0, 180));
      rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, 0);
    }

    if (transform.position.y < -screenSize.y) {
      transform.position = new Vector2(-transform.position.x, -screenSize.y);
      transform.Rotate(new Vector3(0, 0, 180));
      rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, 0);
    }

  }

  #endregion
	
}
