using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Dao;
using DataAcess.Mapper;
using Entities_POJO;

namespace DataAcces.Mapper
{
    public class LocalizacionMapper : EntityMapper, ISqlStaments, IObjectMapper
    {

        private const string DB_COL_IDLOCALIZACION = "idLocalizacion";
        private const string DB_COL_CEDULA = "cedula";
        private const string DB_COL_TIPO = "tipoL";
        private const string DB_COL_VALOR= "valor";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_LOCALIZACION_PR" };

            var l = (Localizacion)entity;
            operation.AddVarcharParam(DB_COL_IDLOCALIZACION,l.idLocalizacion);
            operation.AddVarcharParam(DB_COL_CEDULA, l.cedula);
            operation.AddVarcharParam(DB_COL_TIPO, l.tipoLocalizacion);
            operation.AddVarcharParam(DB_COL_VALOR, l.valor);
            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_LOCALIZACION_PR" };

            var l = (Localizacion)entity;
            operation.AddVarcharParam(DB_COL_CEDULA, l.cedula);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_LOCALIZACION_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_LOCALIZACION_PR" };

            var l = (Localizacion)entity;
            operation.AddVarcharParam(DB_COL_CEDULA, l.cedula);
            operation.AddVarcharParam(DB_COL_TIPO, l.tipoLocalizacion);
            operation.AddVarcharParam(DB_COL_VALOR, l.valor);


            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_LOCALIZACION_PR" };

            var l = (Localizacion)entity;
            operation.AddVarcharParam(DB_COL_CEDULA, l.cedula);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var localizacion = BuildObject(row);
                lstResults.Add(localizacion);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var localizacion = new Localizacion
            {
                idLocalizacion = GetStringValue(row, DB_COL_IDLOCALIZACION),
                cedula = GetStringValue(row, DB_COL_CEDULA),
                tipoLocalizacion = GetStringValue(row, DB_COL_TIPO),
                valor = GetStringValue(row, DB_COL_VALOR)

            };

            return localizacion;
        }

    }
}

