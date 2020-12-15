namespace lab1
{
    interface IDataAccessor
    {
        void Read(IConnection connection, ITransaction transaction, DataSet1 ds);
        void Update(IConnection connection, ITransaction transaction, DataSet1 ds);
    }
}