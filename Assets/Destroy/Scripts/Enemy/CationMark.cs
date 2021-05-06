using UnityEngine;
using DG.Tweening;

public class CationMark : MonoBehaviour
{
    [SerializeField]
    private float displayTime = 1f;

    private void Start()
    {
        transform.DOLocalMoveY(transform.position.y + 1, displayTime / 3f)
              .SetLoops(3)
              .OnComplete(() => Destroy(gameObject));
    }
}
