namespace PRG_282_project
{
    internal class Module
    {
        public Module(string moduleName, string moduleCode, string moduleDescription, string moduleLinks)
        {
            ModuleName = moduleName;
            ModuleCode = moduleCode;
            ModuleDescription = moduleDescription;
            ModuleLinks = moduleLinks;
        }

        public string ModuleName { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleDescription { get; set; }
        public string ModuleLinks { get; set; }


    }
}
