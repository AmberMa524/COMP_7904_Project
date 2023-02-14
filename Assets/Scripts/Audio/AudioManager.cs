using UnityEngine;

// Could add more functionality to this class in the future.
// Add this to any object that has its own sounds.
// In the inspector, you will see a dropdown that says
// 'sounds', then another dropdown that says 'data'.
// In data, you can create key/audiosource pairs.
// In a component that has an AudioManager member ('ab' for our purposes),
// here is how you would play an audio: ab.sounds["Key"].Play();

public class AudioManager : MonoBehaviour
{
    public UMap<AudioSource> sounds;
}
