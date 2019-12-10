using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class ClienteMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_cedula = "cedula";
        private const string DB_COL_nombre = "nombre";
        private const string DB_COL_apellido = "apellido";
        private const string DB_COL_fechaNacimiento = "fechaNacimiento";
        private const string DB_COL_edad = "edad";
        private const string DB_COL_estadoCivil = "estadoCivil";
        private const string DB_COL_genero = "genero";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_CLIENTE_PR" };

            var c = (Cliente)entity;
            operation.AddVarcharParam(DB_COL_cedula, c.cedula);
            operation.AddVarcharParam(DB_COL_nombre, c.nombre);
            operation.AddVarcharParam(DB_COL_apellido, c.apellido);
            operation.AddVarcharParam(DB_COL_fechaNacimiento, c.fechaNacimiento);
            operation.AddIntParam(DB_COL_edad, c.edad);
            operation.AddVarcharParam(DB_COL_estadoCivil, c.estadoCivil);
            operation.AddVarcharParam(DB_COL_genero, c.genero);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CLIENTE_PR" };

            var c = (Cliente)entity;
            operation.AddVarcharParam(DB_COL_cedula,c.cedula);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_cliente_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_Cliente_PR" };

            var c = (Cliente)entity;
            operation.AddVarcharParam(DB_COL_cedula, c.cedula);
            operation.AddVarcharParam(DB_COL_nombre, c.nombre);
            operation.AddVarcharParam(DB_COL_apellido, c.apellido);
            operation.AddVarcharParam(DB_COL_fechaNacimiento, c.fechaNacimiento);
            operation.AddIntParam(DB_COL_edad, c.edad);
            operation.AddVarcharParam(DB_COL_estadoCivil, c.estadoCivil);
            
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_Cliente_PR" };

            var c = (Cliente)entity;
            operation.AddVarcharParam(DB_COL_cedula, c.cedula);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var cliente = BuildObject(row);
                lstResults.Add(cliente);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var cliente = new Cliente
            {
                cedula = GetStringValue(row, DB_COL_cedula),
                nombre = GetStringValue(row, DB_COL_nombre),
                apellido = GetStringValue(row, DB_COL_apellido),
                fechaNacimiento = GetStringValue(row, DB_COL_fechaNacimiento),
                edad = GetIntValue(row, DB_COL_edad),
                estadoCivil = GetStringValue(row, DB_COL_estadoCivil),
                genero = GetStringValue(row, DB_COL_genero)

            };

            return cliente;
        }




    }
}
