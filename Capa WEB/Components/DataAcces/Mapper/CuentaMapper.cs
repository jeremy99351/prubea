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
    public class CuentaMapper : EntityMapper, ISqlStaments, IObjectMapper
    {

        private const string DB_COL_id_cuenta = "id_cuenta";
        private const string DB_COL_nombre = "nombre";
        private const string DB_COL_moneda = "moneda";
        private const string DB_COL_saldo = "saldo";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_CUENTA_PR" };

            var c = (Cuenta)entity;
            operation.AddVarcharParam(DB_COL_id_cuenta, c.idCuenta);
            operation.AddVarcharParam(DB_COL_nombre, c.nombre);
            operation.AddVarcharParam(DB_COL_moneda, c.moneda);
            operation.AddIntParam(DB_COL_saldo, c.saldo);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CUENTA_PR" };
            var c = (Cuenta)entity;
            operation.AddVarcharParam(DB_COL_id_cuenta, c.idCuenta);

            return operation;
        }


        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CUENTA_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_CUENTA_PR" };

            var c = (Cuenta)entity;

            operation.AddVarcharParam(DB_COL_id_cuenta, c.idCuenta);
            operation.AddVarcharParam(DB_COL_nombre, c.nombre);
            operation.AddVarcharParam(DB_COL_moneda, c.moneda);
            operation.AddIntParam(DB_COL_saldo, c.saldo);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_CUENTA_PR" };

            var c = (Cuenta)entity;
            operation.AddVarcharParam(DB_COL_id_cuenta, c.idCuenta);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var cuenta = BuildObject(row);
                lstResults.Add(cuenta);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var cuenta = new Cuenta
            {

                idCuenta = GetStringValue(row, DB_COL_id_cuenta),
                nombre = GetStringValue(row,DB_COL_nombre),
                moneda = GetStringValue(row,DB_COL_moneda),
                saldo = GetIntValue(row,DB_COL_saldo)
                
            };

            return cuenta;
        }
    }
}
