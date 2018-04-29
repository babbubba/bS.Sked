using bS.Sked.Data.Interfaces;
using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Model.Interfaces.Jobs;
using bS.Sked.Services.Base;
using bS.Sked.WMC.Model;
using bS.Sked.WMC.Model.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace bS.Sked.Services.WMC
{
    public class LeftSidebarService : ServiceBase
    {
        private readonly IRepository<IPersisterEntity> repository;

        public LeftSidebarService(IRepository<IPersisterEntity> repository)
        {
            this.repository = repository;
        }

        private void createJobsSection(List<ISidebarItemBase> aResult)
        {
            var query = repository.GetQuery<IJobModel>().OrderBy(x=>x.Position);

            aResult.Add(new SidebarItemHeaderModel
            {
                Text = "Data"
            });

            var jobsMenu = new SidebarItemTreeViewModel
            {
                Text = "Jobs"
            };
            aResult.Add(jobsMenu);

            foreach (var j in query)
            {
                jobsMenu.Children.Add(new SidebarItemModel
                {
                    Text = j.Name,
                    Icon = SidebarItemIcon.Job,
                    IsDisabled = !j.IsActive,
                    Labels = new SidebarItemLabelModel[]
                    {
                        new SidebarItemLabelModel
                        {
                            Text = $"{j.Tasks.Count.ToString()} tasks",
                            TextColour = Colours.blue
                        }
                    },
                    Link = $"/Jobs/Details/{j.Id}"
                });
            }
        }

        private static void createNavigationSection(List<ISidebarItemBase> aResult)
        {
            aResult.Add(new SidebarItemHeaderModel
            {
                Text = "Navigation",
                TextColour = Colours.blue
            });

            aResult.Add(new SidebarItemModel
            {
                Text = "Dashboard",
                Link = "/Home/Dashboard",
                Icon = SidebarItemIcon.tachometer
            });

            var settingsMenu = new SidebarItemTreeViewModel
            {
                Text = "Settings",
                Icon = SidebarItemIcon.cog
            };
            aResult.Add(settingsMenu);

            settingsMenu.Children.Add(new SidebarItemModel
            {
                Text = "SMTP Settings",
                Link = "/SmtpSettings",
                Icon= SidebarItemIcon.envelope
            });

        }

        public ISidebarItemBase[] Items()
        {
            var aResult = new List<ISidebarItemBase>();

            createNavigationSection(aResult);
            createJobsSection(aResult);

            return aResult.ToArray();
        }

        public SidebarItemModel GetItem(ISidebarItemBase model)
        {
            return (SidebarItemModel)model;
        }

        public SidebarItemTreeViewModel GetTreeViewItem(ISidebarItemBase model)
        {
            return (SidebarItemTreeViewModel)model;
        }
    }


}
