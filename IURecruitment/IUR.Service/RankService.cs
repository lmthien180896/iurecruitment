using IUR.Data.Infrastructure;
using IUR.Data.Repositories;
using IUR.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUR.Service
{
    public interface IRankService
    {
        Rank Add(Rank rank);

        Rank GetById(int id);

        Rank Delete(int id);

        IEnumerable<Rank> GetAll();

        void Update(Rank rank);

        void SaveChanges();
    }

    public class RankService : IRankService
    {
        private IRankRepository _rankRepository;
        private IUnitOfWork _unitOfWork;

        public RankService(IRankRepository rankRepository, IUnitOfWork unitOfWork)
        {
            this._rankRepository = rankRepository;
            this._unitOfWork = unitOfWork;
        }

        public Rank Add(Rank rank)
        {
            return _rankRepository.Add(rank);
        }

        public Rank Delete(int id)
        {
            return _rankRepository.Delete(id);
        }

        public IEnumerable<Rank> GetAll()
        {
            return _rankRepository.GetAll();
        }

        public Rank GetById(int id)
        {
            return _rankRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Rank rank)
        {
            _rankRepository.Update(rank);
        }
    }
}


