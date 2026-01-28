using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private float _bgSpeed;
    private Vector2 _offset;

    private Material _material;

    private void Start()
    {
        _material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        _offset = new Vector2(0, _bgSpeed * Time.deltaTime);
        _material.mainTextureOffset += _offset;

        if (_material.mainTextureOffset.y >= 1)
        {
            _material.mainTextureOffset = new Vector2(0, 0);
        }
    }
}