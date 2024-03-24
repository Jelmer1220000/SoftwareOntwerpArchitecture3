namespace Avans_DevOps.Rapport.Document.Parts
{
    public class Footer
    {
        public string? Logo;
        public string? Title;
        public string? Project;
        public string? Version;
        public DateOnly? Date;

        public Footer(string? logo, string? title, string? project, string? version, DateOnly? date)
        {
            Logo=logo; 
            Title=title; 
            Project=project;
            Version=version; 
            Date=date;
        }
    }
}
