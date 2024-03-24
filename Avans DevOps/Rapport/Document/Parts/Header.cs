namespace Avans_DevOps.Rapport.Document.Parts
{
    public class Header
    {
        public string? Logo;
        public string? Title;
        public string? Project;
        public string? Version;
        public DateOnly? Date;

        public Header(string? logo, string? title, string? project, string? version, DateOnly? date)
        {
            Logo = logo;
            Title = title;
            Project = project;
            Version = version;
            Date = date;
        }
    }
}
