using System.ComponentModel;
using System.Web.Services;
using BL;
using lab1;

namespace Web
{
    /// <summary>
    /// Summary description for Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : WebService
    {
        private TypeServiceLogic typeServiceLogic;
        public Service()
        {
            typeServiceLogic = new TypeServiceLogic();
        }
        
        [WebMethod]
        public DataSet1 GetAllTypes()
        {
            typeServiceLogic.FindAll();
            return typeServiceLogic.Cache;
        }
        
        [WebMethod]
        public DataSet1 FindTypeById(long id)
        {
            typeServiceLogic.FindByIdOrThrow(id);
            return typeServiceLogic.Cache;
        }
        
        [WebMethod]
        public bool AddType(DataSet1 dataSet1)
        {
            typeServiceLogic.Add(dataSet1.TypeService[0]);
            return true;
        }
        
        [WebMethod]
        public bool DeleteType(long id)
        {
            return typeServiceLogic.DeleteById(id);
        }
    }
}
