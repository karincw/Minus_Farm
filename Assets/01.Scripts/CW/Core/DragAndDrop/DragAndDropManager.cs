using UnityEngine;

namespace CW
{

    public class DragAndDropManager : MonoSingleton<DragAndDropManager>
    {
        public DragAndDrop dragObject;
        private SpriteRenderer _spriteRenderer;
        private CardSO _card;
        public CardSO Card { get => _card; }
        private bool _isSeed;
        public bool IsSeed { get => _isSeed; set => _isSeed = value; }
        public bool CanDrop { get; private set; }

        public void SetImage(CardSO card)
        {
            _card = card;
            if (_card != null)
            {
                _spriteRenderer.sprite = _card.sprite;
                CanDrop = true;
            }
            else
            {
                _spriteRenderer.sprite = null;
                CanDrop = false;
            }
        }
        public void SetImage(Sprite sprite = null)
        {
            CanDrop = sprite != null;

            _spriteRenderer.sprite = sprite;
        }


        private void Awake()
        {
            _spriteRenderer = dragObject.GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (dragObject != null)
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                dragObject.transform.position = mousePos;
            }
        }

    }

}