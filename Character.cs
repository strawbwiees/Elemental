using System;

public class Character
{
    private string name;
    private string element;
    private int health;
    private int attackPower;
    private int specialUses;
    private bool isDefending;

    public Character(string name, string element, int attackPower)
    {
        this.name = name;
        this.element = element;
        this.health = 100;
        this.attackPower = attackPower;
        this.specialUses = 3;
        this.isDefending = false;
    }

    public string GetName()
    {
        return name;
    }

    public string GetElement()
    {
        return element;
    }

    public int GetHealth()
    {
        return health;
    }

    public int BasicAttack()
    {
        return attackPower;
    }

    public int SpecialAttack()
    {
        if (specialUses > 0)
        {
            specialUses--;
            return attackPower * 2;
        }

        return 0;
    }

    public void Defend()
    {
        isDefending = true;

        Console.WriteLine();
        Console.WriteLine(name + " used Elemental Shield!");
        Console.WriteLine("The next incoming attack will deal half damage.");
    }

    public void TakeDamage(int damage)
    {
        if (isDefending)
        {
            damage = damage / 2;

            Console.WriteLine(name + " defended!");
            Console.WriteLine("Damage reduced by half!");

            isDefending = false;
        }

        health -= damage;

        if (health < 0)
        {
            health = 0;
        }

        Console.WriteLine(name + " received " + damage + " damage!");
        Console.WriteLine(name + "'s HP: " + health + "/100");
    }

    public bool IsAlive()
    {
        return health > 0;
    }

    public void DisplayStatus()
    {
        Console.WriteLine();
        Console.WriteLine("======================================");
        Console.WriteLine("             STATUS");
        Console.WriteLine("======================================");
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Element: " + element);
        Console.WriteLine("Health: " + health + "/100");
        Console.WriteLine("Attack Power: " + attackPower);
        Console.WriteLine("Special Attacks: " + specialUses + "/3");
        Console.WriteLine("Defending: " + (isDefending ? "Yes" : "No"));
        Console.WriteLine("======================================");
    }
}