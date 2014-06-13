using System.Runtime.Serialization;

namespace MusicApi.Models
{
    [DataContract]
    public class NameList
    {
        [DataMember]
        public string Name { get; set; }

        public NameList(string name)
        {
            this.Name = name;
        }
    }
}