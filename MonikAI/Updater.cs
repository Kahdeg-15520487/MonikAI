using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MonikAI
{
    public class Updater
    {
        private static readonly string StatePath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MonikAI");

        private readonly List<Task> downloadTasks = new List<Task>();



        private bool updateProgram;

        public async Task Init()
        {
            if (!MonikaiSettings.Default.AutoUpdate)
            {
                if (MonikaiSettings.Default.FirstLaunch)
                {
                    this.downloadTasks.Add(this.DownloadCSV());
                }

                return;
            }

            Directory.CreateDirectory(Updater.StatePath);

            // Retrieve GitHub releases
            //var latestRelease = (await (new GitHubClient(new ProductHeaderValue("MonikAI"))).Repository.Release.GetAll("PiMaker",
            //    "MonikAI",
            //    new ApiOptions
            //    {
            //        PageCount = 1,
            //        PageSize = 1,
            //        StartPage = 0
            //    })).First();

            //if (MonikaiSettings.Default.GithubReleaseId == -1)
            //{
            //    MonikaiSettings.Default.GithubReleaseId = latestRelease.Id;
            //    MonikaiSettings.Default.Save();
            //}

            //if (MonikaiSettings.Default.GithubReleaseId != latestRelease.Id || true)
            //{
            //    // Application Update detected
            //    this.updateProgram = true;
            //    this.downloadTasks.Add(Task.Run(async () =>
            //    {
            //        var client = new WebClient();
            //        await client.DownloadFileTaskAsync(latestRelease.Assets.First().BrowserDownloadUrl,
            //            Path.Combine(Updater.StatePath, "MonikAI.exe"));
            //    }));
            //}

            // Retrieve CSV releases
            await this.DownloadCSV();
        }

        private Task DownloadCSV()
        {
            throw new NotImplementedException();
        }
    }
}