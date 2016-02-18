using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//public variables
	public float speed = 0.1F;
	public float jump = 100F;
	public Transform groundCheck;

	//private instance variables
	private float move;
	private bool doubleJump;
	private bool grounded;
	private bool facingRight;
	private Animator _animator;
	private Transform _transform;
	private Rigidbody2D _rigidbody2D;

	// Use this for initialization
	void Start () {
		this._transform = gameObject.GetComponent<Transform> ();
		this._animator = gameObject.GetComponent<Animator> ();
		this._rigidbody2D = gameObject.GetComponent<Rigidbody2D> ();
		this.doubleJump = true;
		this.move = 0; 
		this.facingRight = true;
		this.grounded = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Platform")); 

		move = Input.GetAxis("Horizontal");

		if (move > 0) {
			facingRight = true;
			Flip ();
		} 

		if(move < 0) {
			facingRight = false;
			Flip ();
		}

		if (move != 0) {
			_animator.SetInteger ("animState", 1);
			PlayerMovement ();
		} else {
			_animator.SetInteger ("animState", 0);
		}

		if (Input.GetKeyDown(KeyCode.Space)) {
			if (grounded) {
				_animator.SetInteger ("animState", 2);
				_rigidbody2D.velocity = new Vector2 (_rigidbody2D.velocity.x, jump * 10);
				doubleJump = true;
			} else {
				if (doubleJump) {
					_animator.SetInteger ("animState", 2);
					doubleJump = false;
					_rigidbody2D.AddForce (new Vector2 (_rigidbody2D.velocity.x, jump * 100), ForceMode2D.Impulse);
				}
			}
		}

	}

	private void Flip(){
		if (!facingRight)
			this._transform.localScale = new Vector3 (-0.1f, 0.1f);
		else
			this._transform.localScale = new Vector3 (0.1f, 0.1f);
	}

	private void PlayerMovement(){
		_transform.position = new Vector3 (Mathf.Clamp (
			_transform.position.x, -400, 6228), 
			_transform.position.y, 
			_transform.position.z);

		Vector2 _currentPos = _transform.position;
		_currentPos.x += (move * speed);
		_transform.position = _currentPos;
	}
}