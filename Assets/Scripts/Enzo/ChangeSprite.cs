using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{

    [SerializeField] Sprite[] _spriteImages;
    [SerializeField] SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer.sprite = _spriteImages[Random.Range(0, _spriteImages.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
