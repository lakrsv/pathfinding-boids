using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyCorreographer : MonoBehaviour
{
    private List<EnemyAI> _enemies = new List<EnemyAI>();
    public int Range, Influence;
    public float SeperationInfluence, AlignmentInfluence, CohesionInfluence;
    public float MovMod, SepMod, AlMod, CoMod;

    public int EnemyCount
    {
        get
        {
            if (_enemies != null)
            {
                return _enemies.Count;
            }
            else
            {
                return 1;
            }
        }
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            var current = _enemies[i];
            var currentObject = current.gameObject;
            var currentheading = _enemies[i].Heading.normalized;
            var Seperation = new Vector3();
            var Cohesion = new Vector3();
            var Alignment = new Vector3();
            var inRange = 0;
            for (int j = 0; j < _enemies.Count; j++)
            {
                if (i == j)
                {
                    continue;
                }
                var other = _enemies[j];
                var otherheading = _enemies[j].Heading.normalized;
                var otherObject = other.gameObject;
                var dist = Vector3.Distance(currentObject.transform.position, otherObject.transform.position);
                if (dist < Range)
                {
                    inRange++;
                    var SeperationForce = Mathf.Min(1 / dist * SeperationInfluence, SeperationInfluence);
                    Seperation += (currentObject.transform.position - otherObject.transform.position).normalized * SeperationForce;
                    Alignment += otherheading.normalized * AlignmentInfluence;
                    Cohesion += otherObject.transform.position;
                    //SetHeading(current, other);
                }
            }
            Seperation = Seperation.normalized;
            Alignment = Alignment.normalized;
            if (inRange > 0)
            {
                Cohesion = Cohesion / inRange;
                Cohesion = (Cohesion - currentObject.transform.position).normalized;
            }
            current.SetHeading(Seperation, Cohesion, Alignment, MovMod, SepMod, CoMod, AlMod);
        }
    }
    public void Register(EnemyAI enemy)
    {
        _enemies.Add(enemy);
    }
    public void CheckOut(EnemyAI enemy)
    {
        _enemies.Remove(enemy);
    }
}
