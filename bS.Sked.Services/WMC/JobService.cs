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

        private int GetFirstFreePosition()
        {
            if (!_repository.GetQuery<JobModel>().Any()) return 1;
            int pos = _repository.GetQuery<JobModel>().Max(x => x.Position);
            return pos+=1;
        }

        private void MovePositionUp(JobModel jobToMove)
        {
            var prevJob = _repository.GetQuery<JobModel>().Where(x=> x.Position < jobToMove.Position).OrderByDescending(x=>x.Position).FirstOrDefault();
            if (prevJob == null)
            {
                //This is the first one... do nothing
                return;
            }
            var actualJobToMovePos = jobToMove.Position;
            jobToMove.Position = prevJob.Position;
            prevJob.Position = actualJobToMovePos;

            _repository.Update(jobToMove);
            _repository.Update(prevJob);
        }

        private void MovePositionDown(JobModel jobToMove)
        {
            var nextJob = _repository.GetQuery<JobModel>().Where(x => x.Position > jobToMove.Position).OrderBy(x => x.Position).FirstOrDefault();
            if (nextJob == null)
            {
                //This is the last one... do nothing
                return;
            }
            var actualJobToMovePos = jobToMove.Position;
            jobToMove.Position = nextJob.Position;
            nextJob.Position = actualJobToMovePos;

            _repository.Update(jobToMove);
            _repository.Update(nextJob);
        }

        public List<JobTeaserViewModel> JobAll()
        {
            var jobs = _repository.GetQuery<JobModel>().OrderBy(x => x.Position).ToList();
            var jobsVM = Mapping.Map<List<JobTeaserViewModel>>(jobs);
            return jobsVM;
        }

        public JobAddViewModel JobAdd(string name)
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

  
                // Put after the last one
                newJob.Position = GetFirstFreePosition();
        

            // Clean name
            name = name.CleanName();

            // Chek if job name exists
            if (_repository.GetQuery<JobModel>().Any(x => x.Name == name))
            {
                throw new ApplicationException("Job name already exists.");
            }

            newJob.Name = name;

            try
            {
                _repository.Add(newJob);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error creating Job: {ex.GetBaseException().Message}.", ex);
            }

            return Mapping.Map<JobAddViewModel>(newJob);

        }
    }
}
