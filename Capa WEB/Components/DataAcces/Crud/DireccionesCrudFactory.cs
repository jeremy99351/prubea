using System;
using System.Collections.Generic;
using Entities_POJO;
using DataAcess.Mapper;
using DataAcess.Dao;

namespace DataAcess.Crud
{
    public class DireccionesCrudFactory : CrudFactory
    {
        DireccionesMapper mapper;

        public DireccionesCrudFactory() : base()
        {
            mapper = new DireccionesMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var direcciones = (Direcciones)entity;
            var sqlOperation = mapper.GetCreateStatement(direcciones);
            dao.ExecuteProcedure(sqlOperation);
        }



        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstDirecciones = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstDirecciones.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstDirecciones;
        }

        public override void Update(BaseEntity entity)
        {
            var direcciones = (Direcciones)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(direcciones));
        }

        public override void Delete(BaseEntity entity)
        {
            var direcciones = (Direcciones)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(direcciones));
        }
    }
}