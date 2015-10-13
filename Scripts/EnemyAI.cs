using UnityEngine;
using System.Collections;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    private Seeker _mySeeker;
    private Vector3 _targetPosition;
    private GameObject _player;
    private Path _path;
    private float _movSpeed;
    private float _nextWaypointDistance;
    private int _currentWayPoint;
    private Rigidbody _myRigidBody;
    private int _wayPointCount, _neighbourCount;
    private GameObject[] _enemies;
    private Seeker[] _enemySeekers;
    public Vector3 Heading;
    [SerializeField]
    private int _health;

    // Use this for initialization
    void Start()
    {
        _health = 20;
        _currentWayPoint = 0;
        _movSpeed = 20;
        _mySeeker = GetComponent<Seeker>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _myRigidBody = GetComponent<Rigidbody>();
        GameObject.FindGameObjectWithTag("Correographer").GetComponent<EnemyCorreographer>().Register(this);
    }

    // Update is called once per frame
    void Update()
    {
        PathFinding();
        MoveToWayPoint();
    }

    void PathFinding()
    {
        if (_path == null)
        {
            FindPath();
        }
    }
    void FindPath()
    {
        if (_mySeeker.IsDone())
        {
            _targetPosition = _player.transform.position;
            _mySeeker.StartPath(transform.position, _targetPosition, OnPathComplete);
        }
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            _path = p;
            _currentWayPoint = 0;
            _wayPointCount = _path.vectorPath.Count;
        }
    }
    void MoveToWayPoint()
    {
        if (_path != null)
        {
            Vector3 moveDirection = Heading.normalized;
            _myRigidBody.velocity = Vector3.Lerp(_myRigidBody.velocity, moveDirection * _movSpeed, 10 * Time.deltaTime);
            if (Vector3.Distance(transform.position, _path.vectorPath[_currentWayPoint]) < 0.5f)
            {
                if (_path.vectorPath.Count - 1 > _currentWayPoint)
                {
                    _currentWayPoint++;
                }
                else
                {
                    _path = null;
                }
            }
        }
    }
    public void SetHeading(Vector3 Seperation, Vector3 Cohesion, Vector3 Alignment, float m, float s, float c, float a)
    {
        if (_path != null)
        {
            Vector3 moveDirection = (_path.vectorPath[_currentWayPoint] - transform.position).normalized;
            //Swarm Mode
            //moveDirection = (_player.transform.position - transform.position).normalized;
            Heading = moveDirection * m + Seperation * s + Cohesion * c + Alignment * a;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }
    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            CanvasManager CanvasMan = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasManager>();
            CanvasMan.UpdateKillCountText();
            GameObject.FindGameObjectWithTag("Correographer").GetComponent<EnemyCorreographer>().CheckOut(this);
            Destroy(gameObject);
        }
    }
}
