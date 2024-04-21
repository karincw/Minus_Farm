using UnityEngine;

namespace CW
{

    public class DragAndDropManager : MonoSingleton<DragAndDropManager>
    {
        public DragAndDrop dragObject;
        private SpriteRenderer _spriteRenderer;
        private CardSO _card;
        public CardSO Card { get => _card; }
        public bool CanDrop { get; private set; }

        public bool IsSeed;
        public bool IsAction;

        public void SetCard(CardSO card)
        {
            IsAction = false;
            _card = card;
            if (_card != null)
            {
                if(card.actionCard)
                    IsAction = true;
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