namespace Infrastructure.CI_CD
{
    public struct CICDConfig
    {
        public string Namespace { get; set; }
        public RegistryAccess RegistryAccess { get; set; }
    }

    public struct RegistryAccess
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}