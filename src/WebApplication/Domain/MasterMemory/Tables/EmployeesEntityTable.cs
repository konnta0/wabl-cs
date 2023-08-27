// <auto-generated />
#pragma warning disable CS0105
using Domain.Entity.Employee;
using MasterMemory.Validation;
using MasterMemory;
using MessagePack;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System;

namespace Domain.Tables
{
   public sealed partial class EmployeesEntityTable : TableBase<EmployeesEntity>, ITableUniqueValidate
   {
        public Func<EmployeesEntity, int> PrimaryKeySelector => primaryIndexSelector;
        readonly Func<EmployeesEntity, int> primaryIndexSelector;


        public EmployeesEntityTable(EmployeesEntity[] sortedData)
            : base(sortedData)
        {
            this.primaryIndexSelector = x => x.EmpNo;
            OnAfterConstruct();
        }

        partial void OnAfterConstruct();


        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public EmployeesEntity FindByEmpNo(int key)
        {
            var lo = 0;
            var hi = data.Length - 1;
            while (lo <= hi)
            {
                var mid = (int)(((uint)hi + (uint)lo) >> 1);
                var selected = data[mid].EmpNo;
                var found = (selected < key) ? -1 : (selected > key) ? 1 : 0;
                if (found == 0) { return data[mid]; }
                if (found < 0) { lo = mid + 1; }
                else { hi = mid - 1; }
            }
            return default;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public bool TryFindByEmpNo(int key, out EmployeesEntity result)
        {
            var lo = 0;
            var hi = data.Length - 1;
            while (lo <= hi)
            {
                var mid = (int)(((uint)hi + (uint)lo) >> 1);
                var selected = data[mid].EmpNo;
                var found = (selected < key) ? -1 : (selected > key) ? 1 : 0;
                if (found == 0) { result = data[mid]; return true; }
                if (found < 0) { lo = mid + 1; }
                else { hi = mid - 1; }
            }
            result = default;
            return false;
        }

        public EmployeesEntity FindClosestByEmpNo(int key, bool selectLower = true)
        {
            return FindUniqueClosestCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<int>.Default, key, selectLower);
        }

        public RangeView<EmployeesEntity> FindRangeByEmpNo(int min, int max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<int>.Default, min, max, ascendant);
        }


        void ITableUniqueValidate.ValidateUnique(ValidateResult resultSet)
        {
#if !DISABLE_MASTERMEMORY_VALIDATOR

            ValidateUniqueCore(data, primaryIndexSelector, "EmpNo", resultSet);       

#endif
        }

#if !DISABLE_MASTERMEMORY_METADATABASE

        public static MasterMemory.Meta.MetaTable CreateMetaTable()
        {
            return new MasterMemory.Meta.MetaTable(typeof(EmployeesEntity), typeof(EmployeesEntityTable), "EmployeesEntity",
                new MasterMemory.Meta.MetaProperty[]
                {
                    new MasterMemory.Meta.MetaProperty(typeof(EmployeesEntity).GetProperty("EmpNo")),
                    new MasterMemory.Meta.MetaProperty(typeof(EmployeesEntity).GetProperty("BirthDate")),
                    new MasterMemory.Meta.MetaProperty(typeof(EmployeesEntity).GetProperty("FirstName")),
                    new MasterMemory.Meta.MetaProperty(typeof(EmployeesEntity).GetProperty("LastName")),
                    new MasterMemory.Meta.MetaProperty(typeof(EmployeesEntity).GetProperty("Gender")),
                    new MasterMemory.Meta.MetaProperty(typeof(EmployeesEntity).GetProperty("HireDate")),
                },
                new MasterMemory.Meta.MetaIndex[]{
                    new MasterMemory.Meta.MetaIndex(new System.Reflection.PropertyInfo[] {
                        typeof(EmployeesEntity).GetProperty("EmpNo"),
                    }, true, true, System.Collections.Generic.Comparer<int>.Default),
                });
        }

#endif
    }
}