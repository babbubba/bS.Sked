using bs.Sked.Mapping;
using bS.Sked.Data.Interfaces;
using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Model.Jobs;
using bS.Sked.Services.Base;
using bS.Sked.Shared.Extensions;
using bS.Sked.WMC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Services.WMC
{
   public class JobService : ServiceBase
    {
        private readonly IRepository<IPersisterEntity> _repository;

        public JobService(IRepository<IPersisterEntity> repository)
        {
            this._repository = repository;
        }

        public List<JobTeaserViewModel> JobAll()
        {
            var jobs = _repository.GetQuery<JobModel>().OrderBy(x=>x.Position).ToList();
            var jobsVM = Mapping.Map<List<JobTeaserViewModel>>(jobs);
            return jobsVM;
        }

        public JobAddViewModel JobAdd(string name, int position = 0)
        {
            //TODO: Riparti da qui
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("The name field is mandatory", nameof(name));
            }

            var newJob = new JobModel
            {
                CreationDate = DateTime.Now
            };

            if (position > 0)
            {
                // TODO: I have to insert in specified position moving the other jobs

            }

            // Clean name
            name = name.CleanName();

            // Chek if job name exists
            if (_repository.GetQuery<JobModel>().Any(x => x.Name == name))
            {
                throw new ApplicationException("Job name already exists.");
            }

                newJob.Name = name;

            _repository.Add(newJob);

            return Mapping.Map<JobAddViewModel>(newJob);

        }
    }
}
