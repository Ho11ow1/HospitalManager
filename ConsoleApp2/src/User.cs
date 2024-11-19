using System;

class C_User
{
    public void Fn_CreateUser()
    {

    }

    public UInt64 Fn_GetID()
    {
        return (Fn_SetID());
    }

    private readonly Random random = new Random();
    private UInt64 Fn_SetID() 
    {
        UInt64 ID;

        lock (random) // Only allow one thread to use this instead of racing
        {
            ID = ((UInt64)random.NextInt64());
        }

        return ID;
    }
}
