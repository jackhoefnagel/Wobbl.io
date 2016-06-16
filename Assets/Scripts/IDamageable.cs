using UnityEngine;
using System.Collections;

public interface IDamageable {

    void UpdateHealth(float amount, bool giveFeedback = true);

}
