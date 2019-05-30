﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GuidDALBase<TEntity> : DALBase<TEntity>, IGuidDAL<TEntity> where TEntity : class, MobileHis.Data.Interface.IGuidEntity
    {

        public void Delete(Guid guid)
        {
            var entity = Entities.Set<TEntity>().Where(a => a.GID == guid).FirstOrDefault();
            if (entity != null)
                Delete(entity);
        }
        public TEntity Read(Guid guid)
        {
            return Entities.Set<TEntity>().Where(a => a.GID == guid).FirstOrDefault();
        }
    }
    public class IDDALBase<TEntity> : DALBase<TEntity>, IIDDAL<TEntity> where TEntity : class, MobileHis.Data.Interface.IIDEntity
    {
        public void Delete(int ID)
        {
            var entity = Entities.Set<TEntity>().Where(a => a.ID == ID).FirstOrDefault();
            if(entity != null)
                Delete(entity);
        }
        public TEntity Read(int ID)
        {
            return Entities.Set<TEntity>().Where(a => a.ID == ID).FirstOrDefault();
        }
    }
}