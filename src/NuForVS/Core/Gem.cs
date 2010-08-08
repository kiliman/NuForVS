using System.Collections.Generic;

namespace NuForVS.Core
{
    public class Gem
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public bool IsReferenced { get; set; }
        public bool IsRemote { get; set; }
        public IList<string> Assemblies { get; private set; }
        
        public Gem()
        {
            Assemblies = new List<string>();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;

            var gem = (Gem)obj;

            return this.Name == gem.Name
                && this.Version == gem.Version;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
