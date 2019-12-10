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
    public class CreditoMapper : EntityMapper, ISqlStaments, IObjectMapper
    {

        private const string DB_COL_idCredito = "idCredito";
        private const string DB_COL_monto = "monto";
        private const string DB_COL_taza = "taza";
        private const string DB_COL_nombre = "nombre";
        private const string DB_COL_cuota = "cuota";
        private const string DB_COL_fechaInicio = "fechaInicio";
        private const string DB_COL_estado = "estado";
        private const string DB_COL_saldo = "saldo";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_CREDITO_PR" };

            var c = (Credito)entity;
            operation.AddVarcharParam(DB_COL_idCredito, c.idCredito);
            operation.AddIntParam(DB_COL_monto, c.monto);
            operation.AddIntParam(DB_COL_taza, c.taza);
            operation.AddVarcharParam(DB_COL_nombre, c.nombre);
            operation.AddIntParam(DB_COL_cuota, c.cuota);
            operation.AddVarcharParam(DB_COL_fechaInicio, c.fechaInicio);
            operation.AddVarcharParam(DB_COL_estado,c.estado);
            operation.AddIntParam(DB_COL_saldo, c.saldo);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CREDITO_PR" };
            var c = (Credito)entity;
            operation.AddVarcharParam(DB_COL_idCredito, c.idCredito);

            return operation;
        }


        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CREDITO_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_CREDITO_PR" };

            var c = (Credito)entity;

            operation.AddVarcharParam(DB_COL_idCredito, c.idCredito);
            operation.AddIntParam(DB_COL_monto, c.monto);
            operation.AddIntParam(DB_COL_taza, c.taza);
            operation.AddIntParam(DB_COL_cuota, c.cuota);
            operation.AddVarcharParam(DB_COL_fechaInicio, c.fechaInicio);
            operation.AddVarcharParam(DB_COL_estado, c.estado);
            operation.AddIntParam(DB_COL_saldo, c.saldo);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_CREDITO_PR" };

            var c = (Credito)entity;

            operation.AddVarcharParam(DB_COL_idCredito, c.idCredito);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var credito = BuildObject(row);
                lstResults.Add(credito);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var credito = new Credito
            {

                idCredito = GetStringValue(row,DB_COL_idCredito),
                monto = GetIntValue(row,DB_COL_monto),
                taza = GetIntValue(row,DB_COL_taza),
                nombre = GetStringValue(row,DB_COL_nombre),
                cuota = GetIntValue(row,DB_COL_cuota),
                fechaInicio = GetStringValue(row,DB_COL_fechaInicio),
                estado = GetStringValue(row,DB_COL_estado),
                saldo = GetIntValue(row,DB_COL_saldo)

            };

            return credito;
        }
    }
}
