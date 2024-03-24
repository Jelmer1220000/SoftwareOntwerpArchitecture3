using System.Text;
using Avans_DevOps.Rapport.Document.Parts;

namespace Avans_DevOps.Rapport.Document.Document
{
    public class PDFRapport : Rapport
    {

        public PDFRapport(Header? header, Body body, Footer? footer) : base(header, body, footer)
        {
        }

        public override string Generate()
        {
            StringBuilder documentContent = new StringBuilder();

            // Dummy data voor Header
            if (Header != null)
            {
                documentContent.AppendLine("Header:");
                documentContent.AppendLine($"Logo: {Header.Logo}");
                documentContent.AppendLine($"Title: {Header.Title}");
                documentContent.AppendLine($"Project: {Header.Project}");
                documentContent.AppendLine($"Version: {Header.Version}");
                documentContent.AppendLine($"Date: {Header.Date}");
                documentContent.AppendLine("----------------------------------------"); // Horizontale lijn
            }

            // Dummy data voor Body
            documentContent.AppendLine("Body");
            documentContent.AppendLine("Users:");
            foreach (var user in Body.Users)
            {
                documentContent.AppendLine($"- {user.GetName()}");
            }
            documentContent.AppendLine("Sprints:");
            foreach (var sprint in Body.Sprints)
            {
                documentContent.AppendLine($"- {sprint.Name}");
                documentContent.AppendLine($"  Start Date: {sprint.StartDate}");
                documentContent.AppendLine($"  End Date: {sprint.EndDate}");
                documentContent.AppendLine("  Sprint Backlog:");
                foreach (var item in sprint._sprintBackLog)
                {
                    documentContent.AppendLine($"    Item Name: {item.Name}");
                    documentContent.AppendLine($"    Story Points: {item.StoryPoints}");
                    documentContent.AppendLine($"    Description: {item.Description}");
                    documentContent.AppendLine("    Activities:");
                    foreach (var activity in item.Activities)
                    {
                        documentContent.AppendLine($"      - {activity}");
                    }
                }
            }
            documentContent.AppendLine("----------------------------------------"); // Horizontale lijn

            // Dummy data voor Footer
            if (Footer != null)
            {
                documentContent.AppendLine("Footer:");
                documentContent.AppendLine($"Logo: {Footer.Logo}");
                documentContent.AppendLine($"Title: {Footer.Title}");
                documentContent.AppendLine($"Project: {Footer.Project}");
                documentContent.AppendLine($"Version: {Footer.Version}");
                documentContent.AppendLine($"Date: {Footer.Date}");
            }

            return documentContent.ToString();
        }
    }
}
