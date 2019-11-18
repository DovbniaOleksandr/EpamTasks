namespace CustomIoC
{
    internal interface IIoc
    {
        void Register<TInterface, TImplementation>() where TImplementation : TInterface;
        void Register<TInterface>();
        TInterface Create<TInterface>();
    }
}