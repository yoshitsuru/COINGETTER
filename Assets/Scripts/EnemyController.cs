using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public UIController uIController;

    [SerializeField] private LayerMask _stageLayer;

    private Rigidbody2D _rb;
    private float _speed = 6.5f;
    private Vector2 _direction;
    private Vector2 _directionReserve;
    private Animator _anim;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _direction = Vector2.up;
    }

    private void Update()
    {
        _anim.SetBool("isWalking", _directionReserve != Vector2.zero);
        if (_directionReserve != Vector2.zero)
        {
            _anim.SetFloat("X", _directionReserve.x);
            _anim.SetFloat("Y", _directionReserve.y);
            CheckDirection(_directionReserve);
        }
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Vector2 dist = _direction * _speed * Time.fixedDeltaTime;
        _rb.MovePosition(_rb.position + dist);
    }

    private void CheckDirection(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast
            (transform.position, Vector2.one * 0.5f, 0.0f, direction, 1.0f, _stageLayer);

        if (hit.collider == null)
        {
            _direction = direction;
            _directionReserve = Vector2.zero;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        PointController point = other.GetComponent<PointController>();

        if (point != null)
        {
            int index = Random.Range(0, point.Directions.Count);
            _directionReserve = point.Directions[index];
        }
    }

    private void OnCollisionEnter2D(Collision2D collition)
    {
        if (collition.gameObject.CompareTag("Player"))
        {
            uIController.ActiveGameOver();
        }
        if (collition.gameObject.CompareTag("Wall") || collition.gameObject.CompareTag("Enemy"))
        {
            MoveInDirection();
        }
    }

    void MoveInDirection()
    {
        if(_direction == Vector2.up)
        {
            _directionReserve = Vector2.down;
        }
        else if (_direction == Vector2.down)
        {
            _directionReserve = Vector2.up;
        }
        else if (_direction == Vector2.right)
        {
            _directionReserve = Vector2.left;
        }
        else if (_direction == Vector2.left)
        {
            _directionReserve = Vector2.right;
        }
    }
}