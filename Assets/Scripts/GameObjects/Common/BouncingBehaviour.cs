using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBehaviour : MonoBehaviour {

  #region Fields

  private float LIMIT = 0.6f;

  private Rigidbody2D rb;
  private Vector2 screenSize;

  #endregion

  #region Mono Behaviour

  void Awake() {
    rb = GetComponent<Rigidbody2D>();
    screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
  }

  void FixedUpdate() {

    if (transform.position.x > screenSize.x) {
      transform.rotation = GetReflectedRotation(Vector3.left);
      rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y);
    }

    if (transform.position.x < -screenSize.x) {
      transform.rotation = GetReflectedRotation(Vector3.left);
      rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y);
    }

    if (transform.position.y > screenSize.y) {
      transform.rotation = GetReflectedRotation(Vector3.up);
      rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y);
    }

    if (transform.position.y < -screenSize.y) {
      transform.rotation = GetReflectedRotation(Vector3.up);
      rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y);
    }

  }

  #endregion

  #region Private Behaviour

  private Quaternion GetReflectedRotation(Vector3 normal) {
    Vector3 reflectedRotation = 2 * (Vector2.Dot(transform.rotation.eulerAngles, normal)) * normal - transform.rotation.eulerAngles;
    if(normal == Vector3.up)
      return Quaternion.Euler(new Vector3(0, 0, 180) + reflectedRotation);
    else
      return Quaternion.Euler(reflectedRotation);
  }

  #endregion

}