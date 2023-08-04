using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpritesController : MonoBehaviour
{
    public Image[] Sprites;
    public int[] timesOfAnimations;
    public int[] directions;


    private void Start()
    {
        for(int i = 0; i < Sprites.Length; i++)
        {
            StartCoroutine(AnimateSprite(Sprites[i], timesOfAnimations[i], directions[i]));
        }
    }

    private IEnumerator AnimateSprite(Image sprite, int timeInSeconds, int direction)
    {
        while (true)
        {
            LeanTween.rotateAround(sprite.gameObject, Vector3.forward, direction * 360, timeInSeconds).setLoopClamp();
            yield return new WaitForSeconds(timeInSeconds);
        }
    }
}
