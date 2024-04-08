using UnityEngine;

namespace CW
{

    public class DragAndDropManager : MonoSingleton<DragAndDropManager>
    {
        public DragAndDrop dragObject;
        private SpriteRenderer _spriteRenderer;
        private CardSO _card;
        public CardSO Card
        {
            get => _card;
            set
            {
                _card = value;
                if (_card != null)
                {
                    _spriteRenderer.sprite = _card.sprite;
                }
                else
                {
                    _spriteRenderer.sprite = null;
                }
            }
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