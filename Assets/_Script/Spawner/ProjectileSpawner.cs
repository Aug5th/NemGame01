using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : Spawner
{
    private static readonly string fireball = "Fireball";
    public static string Fireball { get => fireball; }

    private static readonly string snowball = "Snowball";
    public static string Snowball { get => snowball; }

    private static readonly string arrow = "Arrow";
    public static string Arrow { get => arrow; }

    protected override void LoadComponents()
    {
        SetPoolName("Projectiles");
        base.LoadComponents();
    }

}


