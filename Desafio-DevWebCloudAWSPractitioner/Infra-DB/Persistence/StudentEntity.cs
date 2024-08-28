namespace Infra_DB.Persistence
{
    public class StudentEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public SchoolInfosEntity SchoolInfos { get; set; }
    }
}
