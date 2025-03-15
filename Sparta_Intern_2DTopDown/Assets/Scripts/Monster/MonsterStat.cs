
using System;
using System.Linq;

public class MonsterStat
{
    public string MonsterID;
    public string Name;
    public string Description;
    public int Attack;
    public float AttackMul;
    public int MaxHP;
    public float MaxHPMul;
    public int AttackRange;
    public float AttackRangeMul;
    public float AttackSpeed;
    public float MoveSpeed;
    public int MinExp;
    public int MaxExp;
    public int[] DropItem;

    public void SetStat(MonsterData monsterData)
    {
        MonsterID = monsterData.MonsterID;
        Name = monsterData.Name;
        Description = monsterData.Description;
        Attack = monsterData.Attack;
        AttackMul = monsterData.AttackMul;
        MaxHP = monsterData.MaxHP;
        MaxHPMul = monsterData.MaxHPMul;
        AttackRange = monsterData.AttackRange;
        AttackRangeMul = monsterData.AttackRangeMul;
        AttackSpeed = monsterData.AttackSpeed;
        MoveSpeed = monsterData.MoveSpeed;
        MinExp = monsterData.MinExp;
        MaxExp = monsterData.MaxExp;
        DropItem = monsterData.DropItem.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    }
}
