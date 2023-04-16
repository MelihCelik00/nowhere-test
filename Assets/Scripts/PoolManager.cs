using Assets.Scripts.Helpers;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts.Managers
{
    public class PoolManager : SingletonBehaviour<PoolManager>
    {
        public ObjectPool<Ball> BallPool { get; private set; }
        [SerializeField] private int defaultBallPoolCapacity = 10;
        [SerializeField] private int defaultPoolSize = 100;
        
        protected override void Awake()
        {
            base.Awake();
            BallPool = new ObjectPool<Ball>(CreateBall, BallOnGet, BallOnRelease, BallOnDestroy, false, defaultBallPoolCapacity, defaultPoolSize);
        }

        private void BallOnDestroy(Ball obj)
        {
            Destroy(obj.gameObject);
        }

        private void BallOnRelease(Ball obj)
        { 
            obj.gameObject.SetActive(false);
        }

        private void BallOnGet(Ball obj)
        {
            obj.gameObject.SetActive(true);
        }

        private Ball CreateBall()
        {
            return Instantiate(Resources.Load<Ball>("Prefabs/Ball"));
        }
    }
}