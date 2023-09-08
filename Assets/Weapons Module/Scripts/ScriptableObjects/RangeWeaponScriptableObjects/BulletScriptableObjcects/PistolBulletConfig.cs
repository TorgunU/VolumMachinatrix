using UnityEngine;

[CreateAssetMenu(fileName = "WeaponConfig",
    menuName = "WeaponConfig/BulletConfig/ New PistolBulletSO", order = 52)]
public class PistolBulletConfig : BulletConfig
{
    [SerializeField] private string _id;

    public string Id { get => _id; set => _id = value; }
}
