using UnityEngine;
using System.Collections;

public class GunRay : MonoBehaviour
{
    private bool _readytoFire;
    private LineRenderer _lineRender;
    public GameObject Grenade;
    public GameObject Mine;
    private float _forceMod;
    private int GrenadeCount, MineCount;
    private CanvasManager _canvasMan;
    // Use this for initialization
    void Start()
    {
        GrenadeCount = 100;
        MineCount = 50;
        _forceMod = 200;
        _readytoFire = true;
        _lineRender = GetComponent<LineRenderer>();
        _canvasMan = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasManager>();
        _canvasMan.MineCount = MineCount;
        _canvasMan.GrenadeCount = GrenadeCount;
        _canvasMan.SetTextCount();
    }

    // Update is called once per frame
    void Update()
    {
        ShootGun();
        ThrowGrenade();
        PlaceMine();
    }
    void FixedUpdate()
    {
    }
    void ShootGun()
    {
        RaycastHit GunHit;
        if (Input.GetMouseButton(0))
        {
            if (_readytoFire)
            {
                _readytoFire = false;
                StartCoroutine(FireDelay());
                Vector3 forward = transform.TransformDirection(Vector3.forward);
                if (Physics.Raycast(transform.position, forward, out GunHit))
                {
                    _lineRender.SetPosition(0, transform.position);
                    _lineRender.SetPosition(1, GunHit.point);
                    if (GunHit.transform.tag == "Enemy")
                    {
                        GunHit.transform.gameObject.GetComponent<EnemyAI>().TakeDamage(10);
                    }
                    else if (GunHit.transform.tag == "GrenadeMaster")
                    {
                        GunHit.transform.gameObject.GetComponent<GrenadeMasterTimer>().Explode();
                    }
                }
            }
        }

    }
    void ThrowGrenade()
    {
        if (Input.GetMouseButtonDown(1) && GrenadeCount > 0)
        {
            GameObject currentGrenade = (GameObject)Instantiate(Grenade, new Vector3(transform.position.x, transform.position.y + 0.43f, transform.position.z + 0.30f), Quaternion.identity);
            currentGrenade.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * _forceMod);
            GrenadeCount--;
            _canvasMan.UpdateAmmoCount("Grenade");
        }
    }
    void PlaceMine()
    {
        if (Input.GetKeyDown(KeyCode.Space) && MineCount > 0)
        {
            GameObject currentMine = (GameObject)Instantiate(Mine, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
            MineCount--;
            _canvasMan.UpdateAmmoCount("Mine");
        }
    }
    IEnumerator FireDelay()
    {
        yield return new WaitForSeconds(0.1F);
        _lineRender.SetPosition(0, Vector3.zero);
        _lineRender.SetPosition(1, Vector3.zero);
        _readytoFire = true;
    }
}
