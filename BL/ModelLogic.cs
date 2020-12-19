using System.Collections.Generic;
using System.Data;
using lab1;

namespace BL
{
    public class ModelLogic : AbstractJoinedLogic<DataSet1.ModelRow>
    {
        protected override AbstractDataAccessor CreateAccessor()
        {
            return new ModelAccessor();
        }

        public ICollection<DataRow> Add(string name, long brandId)
        {
            return Join(Add(CreateModelRow(name, brandId)).Id);
        }
        
        public ICollection<DataRow> Update(long id, string name, long brandId)
        {
            return Join(UpdateExisting(id, CreateModelRow(name, brandId)).Id);
        }

        private DataSet1.ModelRow CreateModelRow(string name, long brandId)
        {
            ThrowIfNotExist(brandId);
            var row = NewRow();
            row.Name = name;
            row.BrandId = brandId;
            return row;
        }

        /**
         * Вернуть дочерние сущности
         */
        public override ICollection<DataRow> GetParent(DataSet1.ModelRow row)
        {
            return new List<DataRow> {LogicFactory.BrandLogic.FindByIdOrThrow(row.BrandId)};
        }

        public ICollection<DataRow> FindAllByAnyParam(
            string name,
            string brandId)
        {
            LogicFactory.BrandLogic.ThrowIfNotExist(brandId);
            FindAll();
            string filter = "";
            filter = AddFilter("Name", name, filter);
            filter = AddFilter("BrandId", ParseIdOrNull(brandId), filter);
            return Join(Filter(filter));
        }
    }
}