using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    float _time;
    float _random;
    int _life;
    Rigidbody _rigidbody;
    List<GameObject> _bulletsList;
    public GameObject _bulletPrefab;
    public GameObject _bullets;
    public GameObject _player;
    public AudioSource _largeFlyingSaucer;
    void Start()
    {
        _bulletsList = new List<GameObject>();
        for (int i = 0; i < 20; i++)
        {
            GameObject _b = Instantiate(_bulletPrefab, transform.position, Quaternion.identity, _bullets.transform);
            _bulletsList.Add(_b);
        }
        _life = 0;
        _rigidbody = GetComponent<Rigidbody>();
        _random = Random.Range(20.0f, 40.0f);
    }
    void Update()
    {
        if (_life == 0)
        {
            _time += Time.deltaTime;
            if (_time > _random)
            {
                _life = 1;
                _largeFlyingSaucer.mute = false;
                StartCoroutine(Shooting());
                int _side = Random.Range(0, 2);
                if (_side == 0)
                {
                    transform.position = new Vector3(Spawn._minVector2.x - 1, Random.Range(Spawn._maxVector2.y * 0.8f, Spawn._minVector2.y * 0.8f), 0);
                    _rigidbody.AddForce(-transform.up * 5, ForceMode.Impulse);
                }
                else
                {
                    transform.position = new Vector3(Spawn._maxVector2.x + 1, Random.Range(Spawn._maxVector2.y * 0.8f, Spawn._minVector2.y * 0.8f), 0);
                    _rigidbody.AddForce(transform.up * 5, ForceMode.Impulse);
                }
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Field")
        {
            Death();
        }
    }
    IEnumerator Shooting()
    {
        while (_life == 1)
        {
            yield return new WaitForSeconds(Random.Range(2.0f, 5.0f));
            foreach (var Bullet in _bulletsList)
            {
                if (!Bullet.activeSelf)
                {
                    Sound._sound = 1;
                    Bullet.SetActive(true);
                    Bullet.transform.position = transform.position;
                    Rigidbody _rigidbodyBullet = Bullet.GetComponent<Rigidbody>();
                    _rigidbodyBullet.velocity = Vector3.zero;
                    Vector2 _vector = (_player.transform.position - transform.position).normalized;
                    _rigidbodyBullet.AddForce(_vector * 10, ForceMode.Impulse);
                    break;
                }
            }
        }
    }
    public void Death()
    {
        _largeFlyingSaucer.mute = true;
        _life = 0;
        _random = Random.Range(20.0f, 40.0f);
        _time = 0;
        _rigidbody.velocity = Vector3.zero;
        transform.position = new Vector3(100, 100, 0);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            other.gameObject.SetActive(false);
            Player._score += 200;
            Death();
        }
    }
}