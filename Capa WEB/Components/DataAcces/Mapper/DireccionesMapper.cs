using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities_POJO;
using DataAcess.Dao;

namespace DataAcess.Mapper
{
    public class DireccionesMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_PROVINCIA = "PROVINCIA";
        private const string DB_COL_CANTON = "CANTON";
        private const string DB_COL_DISTRITO = "DISTRITO";
        private const string DB_COL_NOMBRE = "NOMBRE";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_DIRECCIONES_PR" };

            var d = (Direcciones)entity;
            operation.AddVarcharParam(DB_COL_PROVINCIA, d.Provincia);
            operation.AddVarcharParam(DB_COL_CANTON, d.Canton);
            operation.AddVarcharParam(DB_COL_DISTRITO, d.Distrito);
            operation.AddVarcharParam(DB_COL_NOMBRE,d.nombre);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_DIRECCIONES_PR" };

            var d = (Direcciones)entity;
            operation.AddVarcharParam(DB_COL_PROVINCIA, d.Provincia);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_DIRECCIONES_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_DIRECCIONES_PR" };

            var d = (Direcciones)entity;
            operation.AddVarcharParam(DB_COL_PROVINCIA, d.Provincia);
            operation.AddVarcharParam(DB_COL_CANTON, d.Canton);
            operation.AddVarcharParam(DB_COL_DISTRITO, d.Distrito);
            

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_DIRECCIONES_PR" };

            var d = (Direcciones)entity;
            operation.AddVarcharParam(DB_COL_PROVINCIA, d.Provincia);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var direcciones = BuildObject(row);
                lstResults.Add(direcciones);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var direcciones = new Direcciones
            {
                Provincia = GetStringValue(row, DB_COL_PROVINCIA),
                Canton = GetStringValue(row, DB_COL_CANTON),
                Distrito = GetStringValue(row, DB_COL_DISTRITO),
                nombre = GetStringValue(row,DB_COL_NOMBRE)
            };

            return direcciones;
        }

    }
}