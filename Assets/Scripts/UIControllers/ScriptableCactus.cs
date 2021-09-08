using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New obsticle", menuName = "Obsticle")]
public class ScriptableCactus : ScriptableObject
{
    public Sprite obsticleSprite;
    public GameObject cactusPrefab;

    public float speed = 3f;
}
