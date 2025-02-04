// <auto-generated />
#pragma warning disable CS0105
using MasterMemory.Validation;
using MasterMemory;
using MessagePack;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Domain.Entity.Employee;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System;

namespace Shared.Domain.Tables
{
   public sealed partial class TitlesEntityTable : TableBase<TitlesEntity>, ITableUniqueValidate
   {
        public Func<TitlesEntity, (int EmpNo, DateTime FromDate)> PrimaryKeySelector => primaryIndexSelector;
        readonly Func<TitlesEntity, (int EmpNo, DateTime FromDate)> primaryIndexSelector;


        public TitlesEntityTable(TitlesEntity[] sortedData)
            : base(sortedData)
        {
            this.primaryIndexSelector = x => (x.EmpNo, x.FromDate);
            OnAfterConstruct();
        }

        partial void OnAfterConstruct();


        public TitlesEntity FindByEmpNoAndFromDate((int EmpNo, DateTime FromDate) key)
        {
            return FindUniqueCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<(int EmpNo, DateTime FromDate)>.Default, key, false);
        }
        
        public bool TryFindByEmpNoAndFromDate((int EmpNo, DateTime FromDate) key, out TitlesEntity result)
        {
            return TryFindUniqueCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<(int EmpNo, DateTime FromDate)>.Default, key, out result);
        }

        public TitlesEntity FindClosestByEmpNoAndFromDate((int EmpNo, DateTime FromDate) key, bool selectLower = true)
        {
            return FindUniqueClosestCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<(int EmpNo, DateTime FromDate)>.Default, key, selectLower);
        }

        public RangeView<TitlesEntity> FindRangeByEmpNoAndFromDate((int EmpNo, DateTime FromDate) min, (int EmpNo, DateTime FromDate) max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<(int EmpNo, DateTime FromDate)>.Default, min, max, ascendant);
        }


        void ITableUniqueValidate.ValidateUnique(ValidateResult resultSet)
        {
#if !DISABLE_MASTERMEMORY_VALIDATOR

            ValidateUniqueCore(data, primaryIndexSelector, "(EmpNo, FromDate)", resultSet);       

#endif
        }

#if !DISABLE_MASTERMEMORY_METADATABASE

        public static MasterMemory.Meta.MetaTable CreateMetaTable()
        {
            return new MasterMemory.Meta.MetaTable(typeof(TitlesEntity), typeof(TitlesEntityTable), "TitlesEntity",
                new MasterMemory.Meta.MetaProperty[]
                {
                    new MasterMemory.Meta.MetaProperty(typeof(TitlesEntity).GetProperty("EmpNo")),
                    new MasterMemory.Meta.MetaProperty(typeof(TitlesEntity).GetProperty("Title")),
                    new MasterMemory.Meta.MetaProperty(typeof(TitlesEntity).GetProperty("FromDate")),
                    new MasterMemory.Meta.MetaProperty(typeof(TitlesEntity).GetProperty("ToDate")),
                },
                new MasterMemory.Meta.MetaIndex[]{
                    new MasterMemory.Meta.MetaIndex(new System.Reflection.PropertyInfo[] {
                        typeof(TitlesEntity).GetProperty("EmpNo"),
                        typeof(TitlesEntity).GetProperty("FromDate"),
                    }, true, true, System.Collections.Generic.Comparer<(int EmpNo, DateTime FromDate)>.Default),
                });
        }

#endif
    }
}