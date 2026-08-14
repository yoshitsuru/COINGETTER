using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // インプットアクションの定義
    public InputSystem_Actions _inputActions;

    [SerializeField]
    private LayerMask _stageLayer;

    // Regitbody2D,Animator,Vector2の変数
    private Rigidbody2D _rb;
    private Animator _anim;
    private Vector2 _direction;

    // プレイヤーの速度
    [SerializeField]
    private float _speed = 8.0f;

    private void Start()
    {
        // プレイヤーの各設定の取得
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _inputActions = new InputSystem_Actions();
        _inputActions.Enable();
    }

    private void Update()
    {
        // directionの取得(インプットアクションの設定を取得する)
        _direction = _inputActions.Player.Move.ReadValue<Vector2>();
        // 動いているときは動作時のアニメーションを動作させる
        _anim.SetBool("isWalking", _direction != Vector2.zero);
        if (_direction != Vector2.zero)
        {
            _anim.SetFloat("X", _direction.x);
            _anim.SetFloat("Y", _direction.y);
        }
        transform.Translate(_direction * _speed * Time.deltaTime);
    }
}
