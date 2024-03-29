﻿using Microsoft.EntityFrameworkCore;
using ProinterV.Domain.Interfaces;
using ProinterV.Domain.Models;
using ProinterV.Infra.Data.Context;
using System;
using System.Linq;

namespace ProinterV.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbProinterContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(DbProinterContext context)
        {
            Db = context;
            Db.Aluno.Include(g => g.GrupoTrabalho)
                    .Include(t => t.Tarefa);
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
