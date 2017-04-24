using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidLg : MonoBehaviour, IAsteroid {

  public AsteroidType Type { get { return type; } }
  [SerializeField] private AsteroidType type = AsteroidType.Large;

  public int Pieces { get { return pieces; } }
  [SerializeField] private int pieces = 2;

  public float Speed { get { return speed; } }
  [SerializeField] private int speed = 1;
    
  public int Score { get { return score; } }
  [SerializeField] private int score = 20;

  public int Lives { get { return lives; } }
  [SerializeField] private int lives = 1;
	
}
