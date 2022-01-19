﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntraNetAPI.Interfaces;
using IntraNetAPI.Tools;
using IntraNetAPI.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace IntraNetAPI.Repositories
{
    public class CollaboratorRepository : BaseRepository, IRepository<Collaborator>
    {
        public CollaboratorRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public Collaborator FinById(int id)
        {
            return _dataContext.Collaborators.Include(c => c.Holidays).Include(c => c.Missions).FirstOrDefault(b => b.Id == id);
        }
        public IEnumerable<Collaborator> GetAll()
        {
            return _dataContext.Collaborators.Include(c => c.Holidays).Include(c => c.Missions);
        }
        public bool Save(Collaborator element)
        {
            _dataContext.Collaborators.Add(element);
            return _dataContext.SaveChanges() > 0;
        }
        public IEnumerable<Collaborator> Search(Expression<Func<Collaborator, bool>> predicate)
        {
            return _dataContext.Collaborators.Include(c => c.Holidays).Include(c => c.Missions).Where(predicate);
        }
        public Collaborator SearchOne(Expression<Func<Collaborator, bool>> searchMethode)
        {
            return _dataContext.Collaborators.Include(c => c.Holidays).Include(c => c.Missions).Where(searchMethode).FirstOrDefault();
        }
        public bool Update(Collaborator element)
        {
            return _dataContext.SaveChanges() > 0;
        }
    }
}