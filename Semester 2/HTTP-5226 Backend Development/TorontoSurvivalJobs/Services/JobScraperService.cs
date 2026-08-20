using System.Globalization;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using TorontoSurvivalJobs.Models;
namespace TorontoSurvivalJobs.Services
{
    public class JobScraperService
    {
        public List<ScrapedJob> ScrapeJobs(string html)
        {
            var jobs = new List<ScrapedJob>();

            var document = new HtmlDocument();
            document.LoadHtml(html);

            // Target the main card containers for each job listing
            var jobCards = document.DocumentNode
                .SelectNodes("//div[contains(@class, 'sc-hTBlOs')]");

            if (jobCards == null)
            {
                return jobs;
            }

            foreach (var card in jobCards)
            {
                // Title (h1 node inside the header section)
                var title = card
                    .SelectSingleNode(".//h1[contains(@class, 'sc-gjcoXW')]")
                    ?.InnerText
                    .Trim();

                // Job Type (Combines tags like 'Full-time', 'Part-time')
                var jobTypeNodes = card
                    .SelectNodes(".//div[contains(@class, 'sc-jgqiaS')]//span");

                var jobType = jobTypeNodes != null
                    ? string.Join(", ", jobTypeNodes.Select(n => HtmlEntity.DeEntitize(n.InnerText).Trim()))
                    : null;

                // Description text
                var descriptionRaw = card
                    .SelectSingleNode(".//div[contains(@class, 'sc-cmMxcv')]")
                    ?.InnerText;
                var description = descriptionRaw != null
                    ? HtmlEntity.DeEntitize(descriptionRaw).Trim()
                    : null;

                // Location Address string
                var location = card
                    .SelectSingleNode(".//div[contains(@class, 'e5KiSkcjp_YiIIkHDmU3')]")
                    ?.InnerText
                    .Trim();

                // Company is embedded inside description or defaults to Tim Hortons
                // var company = "Tim Hortons";

                // HigherMe cards do not display explicit salary ranges
                string? salary = null;
                var (salaryMin, salaryMax) = ParseSalary(salary);

                var job = new ScrapedJob
                {
                    Title = HtmlEntity.DeEntitize(title ?? string.Empty),
                    CompanyId = 1,
                    LocationId = 1,
                    SalaryMin = salaryMin,
                    SalaryMax = salaryMax,
                    JobType = jobType,
                    Description = description,
                    Url=""
                };

                jobs.Add(job);
            }

            return jobs;
        }
        private (decimal? min, decimal? max) ParseSalary(string? salary)
        {
            if (string.IsNullOrWhiteSpace(salary))
            {
                return (null, null);
            }

            var numbers = Regex.Matches(
                salary,
                @"\d+(?:\.\d+)?");

            if (numbers.Count == 0)
            {
                return (null, null);
            }

            decimal first = decimal.Parse(
                numbers[0].Value,
                CultureInfo.InvariantCulture);

            if (numbers.Count >= 2)
            {
                decimal second = decimal.Parse(
                    numbers[1].Value,
                    CultureInfo.InvariantCulture);

                return (first, second);
            }

            return (first, first);
        }
    }
}