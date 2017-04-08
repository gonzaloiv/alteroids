using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour {

  #region Fields

  private float THRUST = 1f;
  private Rigidbody2D rb;
  private Vector2 direction;

  #endregion

  #region Mono Behaviour

  void Awake() {
    rb = GetComponent<Rigidbody2D>();
  }

  void Update() {
    transform.position = (Vector2) transform.position + direction * THRUST * Time.deltaTime;
  }

  void OnEnable() {
    SetDirection();
  }

  void OnCollisionEnter2D(Collision2D collision2D) {
    if (collision2D.gameObject.layer == (int) Layer.Player)
      gameObject.SetActive(false);  
  }

  #endregion

  #region Private Behaviour

  private void SetDirection() {
    direction = new Vector2(new int[] { -1, 1 }[Random.Range(0, 2)], new int[] { -1, 1 }[Random.Range(0, 2)]);
  }

  #endregion

}
