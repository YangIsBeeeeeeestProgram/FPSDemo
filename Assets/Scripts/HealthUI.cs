using UnityEngine;
using UnityEngine.UI;

public class HealthUI: MonoBehaviour {

    [SerializeField]
    Slider healthSlider;

    private void Update()
    {
        int health = Player.Instance.HP;
        healthSlider.value = (float)health / Player.Instance.MAX_HP;
    }
}