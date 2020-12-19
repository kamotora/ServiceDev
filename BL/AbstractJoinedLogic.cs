using System.Collections.Generic;
using System.Data;

namespace BL
{
    public abstract class AbstractJoinedLogic<T> : AbstractLogic<T> where T : DataRow
    {
        public ICollection<DataRow> FindAllJoined()
        {
            return Join(base.FindAll());
        }

        public ICollection<DataRow> FindByIdOrThrowJoined(long id)
        {
            return Join(id);
        }

        /**
         * Вернуть rows с дочерними сущностями
         */
        public ICollection<DataRow> Join(List<T> rows)
        {
            var list = new HashSet<DataRow>();
            foreach (var row in rows)
            {
                list.Add(row);
                foreach (var parentRow in GetParent(row))
                    list.Add(parentRow);
            }

            return list;
        }

        /**
         * Вернуть дочерние сущности
         */
        public abstract ICollection<DataRow> GetParent(T row);

        /**
         * Вернуть row с id с дочерними сущностями
         */
        public ICollection<DataRow> Join(long id)
        {
            var row = FindByIdOrThrow(id);
            var rows = GetParent(row);
            rows.Add(row);
            return rows;
        }
    }
}