using System.Xml.Serialization;
using FubuCore;

namespace ripple.Model
{
    [XmlType("ripple")]
    public class SolutionConfig
    {
        public static readonly string FileName = "ripple.config";

        public SolutionConfig()
        {
            NugetSpecFolder = "packaging/nuget";
            SourceFolder = "src";
            BuildCommand = "rake";
            FastBuildCommand = "rake compile";
        }

        public string Name { get; set; }
        public string NugetSpecFolder { get; set; }
        public string SourceFolder { get; set; } // look for packages.config underneath this

        public string BuildCommand { get; set; }
        public string FastBuildCommand { get; set; }

        public static SolutionConfig LoadFrom(string directory)
        {
            var fileSystem = new FileSystem();
            var file = directory.AppendPath(FileName);

            return fileSystem.FileExists(file) 
                ? fileSystem.LoadFromFile<SolutionConfig>(file) 
                : null;
            
            
        }
    }
}