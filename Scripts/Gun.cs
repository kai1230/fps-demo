using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range = 100f;
    public float damage = 20f;
    public Camera fpsCam;
    public AudioClip shootSound;               // 開槍音效
    private AudioSource audioSource;           // 音效播放器

    void Start()
    {
        // 取得或新增 AudioSource 組件
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;
        audioSource.clip = shootSound;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // 播放開槍音效
        if (shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }

        Ray ray = new Ray(fpsCam.transform.position, fpsCam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range))
        {
            Debug.Log("Hit: " + hit.collider.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
