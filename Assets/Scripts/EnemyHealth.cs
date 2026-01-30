using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _bulletDamage;
    private float _currentHealth;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _currentHealth = _health;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage()
    {
        Debug.Log("Hacer daño");

        _currentHealth -= _bulletDamage;

        StartCoroutine(DamageFlash());

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator DamageFlash()
    {
        Color originalColor = _spriteRenderer.color;
        _spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        _spriteRenderer.color = originalColor;
    }
}