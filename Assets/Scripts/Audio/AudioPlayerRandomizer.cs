using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerRandomizer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _clip;
    public float repeatTime = 10.0f; // ����� ���������� � �������

    private void Start()
    {
        StartCoroutine(RepeatCoroutine());
    }

    private IEnumerator RepeatCoroutine()
    {
        while (true)
        {
            // ��������� ��� ������ �������
            RandomizeSong();

            // ���� 10 �����
            yield return new WaitForSeconds(repeatTime * 60.0f);
        }
    }

    private void RandomizeSong()
    {
        _audioSource.PlayOneShot(_clip[Random.Range(0, _clip.Length)]);
    }
}
