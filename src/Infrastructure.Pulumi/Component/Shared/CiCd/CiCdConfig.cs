namespace Infrastructure.Pulumi.Component.Shared.CiCd
{
    public struct CiCdConfig
    {
        public RegistryAccess RegistryAccess { get; set; }
    }

    public struct RegistryAccess
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}