using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMd : MonoBehaviour, IAsteroid {

  public AsteroidType Type { get { return type; } }
  [SerializeField] private AsteroidType type = AsteroidType.Medium;

  public int Pieces { get { return pieces; } }
  [SerializeField] private int pieces = 4;

  public float Speed { get { return speed; } }
  [SerializeField] private int speed = 2;
    
  public int Score { get { return score; } }
  [SerializeField] private int score = 50;

  public int Lives { get { return lives; } }
  [SerializeField] private int lives = 1;

}
