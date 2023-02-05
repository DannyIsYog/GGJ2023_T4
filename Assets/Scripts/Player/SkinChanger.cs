using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinChanger : MonoBehaviour
{
    public Sprite[] skins;
    // Start is called before the first frame update
    void Start()
    {
        // choose a random skin
        int skinIndex = Random.Range(0, skins.Length);
        // get the sprite renderer
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        // set the sprite
        sr.sprite = skins[skinIndex];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
