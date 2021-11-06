using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicSoundSystem : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> audioClips_stoneFloor;
    public List<AudioClip> audioClips_woodenFloor;

    private float currentVelocity = 0;
    private Vector3 lastPosition;

    private bool isPlayingSound = false;
    private string lastCollisionTag = "StoneFloor";



    private void Start()
    {
        lastPosition = transform.position;
    }

    private void FixedUpdate()
    {
        currentVelocity = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
    }


    private void OnTriggerStay(Collider collider)
    {
        // Остановка
        if (isPlayingSound == true   &   currentVelocity <= 0.0001f)
        {
            StopAllCoroutines();
            isPlayingSound = false;
        }

        // Начало движения
        if (isPlayingSound == false   &   currentVelocity > 0.0001f)
        {
            if (collider.gameObject.tag == "StoneFloor")
            {
                IEnumerator enumerator = ShuffledPlaying(audioClips_stoneFloor);
                StartCoroutine(enumerator);
            }
            if (collider.gameObject.tag == "WoodenFloor")
            {
                IEnumerator enumerator = ShuffledPlaying(audioClips_woodenFloor);
                StartCoroutine(enumerator);
            }

            isPlayingSound = true;
        }

        // Изменилась поверхность пола
        if ((collider.gameObject.tag == "StoneFloor"  | collider.gameObject.tag == "WoodenFloor")   &   lastCollisionTag != collider.gameObject.tag)
        {
            StopAllCoroutines();
            
            if (collider.gameObject.tag == "StoneFloor")
            {
                IEnumerator enumerator = ShuffledPlaying(audioClips_stoneFloor);
                StartCoroutine(enumerator);
            }
            if (collider.gameObject.tag == "WoodenFloor")
            {
                IEnumerator enumerator = ShuffledPlaying(audioClips_woodenFloor);
                StartCoroutine(enumerator);
            }

            lastCollisionTag = collider.gameObject.tag;
            isPlayingSound = true;
        }


    }




    public IEnumerator ShuffledPlaying(List<AudioClip> audioClips)
    {
        while (true)
        {
            int i = Random.Range(0, audioClips.Count);
            AudioClip newAudioClip = audioClips[i];

            audioSource.clip = newAudioClip;
            audioSource.Play();

            yield return new WaitForSeconds(newAudioClip.length);
        }
    }


}
