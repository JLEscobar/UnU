using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;



public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public bool isMoving;
    public LayerMask SolidObjectsLayer;
    private Vector2 input;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");



            if (input.x != 0) input.y = 0;
            if (input != Vector2.zero)
            {
                animator.SetFloat("Horizontal", input.x);
                animator.SetFloat("Vertical", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (IsWalkable(targetPos))
                    StartCoroutine(Move(targetPos));
            }
        }

        animator.SetBool("IsMoving", isMoving);
    }
    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }
    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.2f, SolidObjectsLayer) != null)
        {
            return false;
        }

        return true;
    }
}
