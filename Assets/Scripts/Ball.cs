using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Ball : MonoBehaviour
    {
        public Color Color { get => _spriteRenderer.color; }
        protected SpriteRenderer _spriteRenderer;

        //TODO: Implement 2 types of balls which has red and blue colors.
        //OPTIONAL: Think outside the box.

        public List<Color> colorList;

        protected virtual void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void Start()
        {
            colorList = new List<Color>(){ Color.red, Color.blue};
            Color randomColor = colorList[Random.Range(0, colorList.Count)];
            _spriteRenderer.color = randomColor;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
    }
}
