﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using IntraNetAPI.Interfaces;
using IntraNetAPI.Models;
using IntraNetAPI.Tools;

namespace IntraNetAPI.Repositories
{
    public class CollaboratorRepository : BaseRepository, IRepository<Collaborator>
    {
        public CollaboratorRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public bool Save(Collaborator element)
        {
            throw new NotImplementedException();
        }

        public bool Update(Collaborator element)
        {
            throw new NotImplementedException();
        }

        public Collaborator FinById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Collaborator> Search(Expression<Func<Collaborator, bool>> predicate)
        {
            return _dataContext.Collaborators.Where(s => s.IsChief == true);
        }

        public Collaborator SearchOne(Expression<Func<Collaborator, bool>> searchMethode)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Collaborator> GetAll()
        {
            return _dataContext.Collaborators;
        }
    }
}