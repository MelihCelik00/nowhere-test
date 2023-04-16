using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class SpawnManager : MonoBehaviour
    {
        private List<Ball> _balls = new List<Ball>();
        public static event Action OnInstantiate;
        public static event Action OnRemove;
        

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
                bool isAnyRedBall = false;
                //TODO: This should remove all red balls, right? 
                // changed to for loop because previous one does not delete all at once, so we had to iterate
                for (int ball = 0; ball < _balls.Count; ball++) 
                {
                    if (_balls[ball].Color == Ball.Colors.Red)
                    {
                        isAnyRedBall = true;
                        RemoveBall(_balls[ball]);
                        ball--;
                    }
                }
                if (isAnyRedBall)
                {
                    OnRemove?.Invoke();
                }
            }
        }

        public void RemoveBall(Ball ball)
        {
            //TODO: Implement a way to remove a ball from the scene and the list.
            _balls.Remove(ball);
            PoolManager.Instance.BallPool.Release(ball);
        }

        private void SpawnBallAtMouseAndGiveName(Vector3 mousePosition, string name)
        {
            //TODO: Spawn a random color of ball at the position of the mouse click and play spawn sound.
            var ball = InstantiateBall(mousePosition);
            ball.Color = (Ball.Colors) Random.Range(0, Enum.GetValues(typeof(Ball.Colors)).Length);
            ball.SetName(name);
            
            //OPTIONAL: Use events for playing sounds.
            OnInstantiate?.Invoke();
        }

        private Ball InstantiateBall(Vector3 position)
        {
            var ball = PoolManager.Instance.BallPool.Get();
            ball.transform.position = position;
            _balls.Add(ball);
            return ball;
        }
    }
}