using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject _ballPrefab;

        private List<Ball> _balls = new List<Ball>();

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f;  
                SpawnBallAtMouseAndGiveName(mousePosition, "Colored Ball");
            }
            else if (Input.GetMouseButtonDown(1))
            {
                //TODO: This should remove all red balls, right? 
                
                // changed to for loop because previous one does not delete all at once, so we had to iterate
                for (int ball = 0; ball < _balls.Count; ball++) 
                {
                    if (_balls[ball].Color == Color.red)
                    {
                        RemoveBall(_balls[ball]);
                        ball--;
                    }
                }
            }
        }

        public void RemoveBall(Ball ball)
        {
            //TODO: Implement a way to remove a ball from the scene and the list.
            _balls.Remove(ball);
            Destroy(ball.gameObject);
        }

        private void SpawnBallAtMouseAndGiveName(Vector3 mousePosition, string name)
        {
            //TODO: Spawn a random color of ball at the position of the mouse click and play spawn sound.
            Color randomColor = new Color(Random.value, Random.value, Random.value);
            InstantiateBall(mousePosition, name, randomColor);
            
            //OPTIONAL: Use events for playing sounds.
        }

        private Ball InstantiateBall(Vector3 position, string name, Color color)
        {
            Ball ball = Instantiate(_ballPrefab, position, Quaternion.identity).GetComponent<Ball>();    
            ball.SetName(name);
            ball.GetComponent<SpriteRenderer>().color = color;
            _balls.Add(ball);
            return ball;
        }
    }
}