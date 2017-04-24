using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSm : MonoBehaviour, IAsteroid {

  public AsteroidType Type { get { return type; } }
  [SerializeField] private AsteroidType type = AsteroidType.Small;

  public int Pieces { get { return pieces; } }
  [SerializeField] private int pieces = 0;

  public float Speed { get { return speed; } }
  [SerializeField] private int speed = 3;
    
  public int Score { get { return score; } }
  [SerializeField] private int score = 100;

  public int Lives { get { return lives; } }
  [SerializeField] private int lives = 1;

}
