using System;

public class BankAccount
{
    private float _balance;
    private bool _active;
    private object _lock = new object();

    public BankAccount()
    {
        _balance = 0;
        _active = false;
    }
    public void Open() => _active = true;

    public void Close() => _active = false;

    public float Balance
    {
        get
        {
            if(!_active) throw new InvalidOperationException("Cannot get balance of closed account.");
            return _balance;
        }
    }

    public void UpdateBalance(float change)
    {
        lock(_lock) _balance += change;
    }
}
