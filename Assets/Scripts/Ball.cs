using System;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Ball : MonoBehaviour
    {
        public enum Colors
        {
            Red,
            Blue
        }

        public Colors Color
        {
            get => _color;
            set
            {
                _color = value;
                _spriteRenderer.color = ColorMap[_color];
            }
        }
        
        private Colors _color;
        protected SpriteRenderer _spriteRenderer;
        
        //TODO: Implement 2 types of balls which has red and blue colors.
        //OPTIONAL: Think outside the box.
        
        // For further cases, art directors/artists/etc. can change the color easily from ScriptableObjects
        // SO is not implemented for now, but can be implemented easily
        public static Dictionary<Colors,UnityEngine.Color> ColorMap = new Dictionary<Colors, UnityEngine.Color>()
        {
            {Colors.Red, UnityEngine.Color.red},
            {Colors.Blue, UnityEngine.Color.blue}
        };

        protected virtual void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void SetName(string name)
        {
            this.name = name;
        }
    }
}
