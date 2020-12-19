using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
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
        private readonly TypeServiceLogic _typeServiceLogic;
        private readonly BrandLogic _brandLogic;
        private readonly ClientLogic _clientLogic;
        private readonly WorkerLogic _workerLogic;
        private readonly ServiceLogic _serviceLogic;
        private readonly ModelLogic _modelLogic;
        private readonly CarLogic _carLogic;

        public Service()
        {
            _typeServiceLogic = LogicFactory.TypeServiceLogic;
            _brandLogic = LogicFactory.BrandLogic;
            _clientLogic = LogicFactory.ClientLogic;
            _workerLogic = LogicFactory.WorkerLogic;
            _serviceLogic = LogicFactory.ServiceLogic;
            _modelLogic = LogicFactory.ModelLogic;
            _carLogic = LogicFactory.CarLogic;
        }
        /**
         * Types
         */
        
        [WebMethod]
        public DataSet1 GetAllTypes()
        {
            _typeServiceLogic.FindAll();
            return _typeServiceLogic.Cache;
        }
        
        [WebMethod]
        public DataSet1 FindTypeById(long id)
        {
            return Wrap(_typeServiceLogic.FindByIdOrThrow(id));
        }
        
        [WebMethod]
        public DataSet1 AddType(string name)
        {
            return Wrap(_typeServiceLogic.Add(name));
        }
        
                
        [WebMethod]
        public DataSet1 UpdateType(long id, string name)
        {
            return Wrap(_typeServiceLogic.Update(id, name));
        }
        
        
        [WebMethod]
        public bool DeleteType(long id)
        {
            return _typeServiceLogic.DeleteById(id);
        }
        
        /**
         * Brand
         */
        [WebMethod]
        public DataSet1 GetAllBrands()
        {
            _brandLogic.FindAll();
            return _brandLogic.Cache;
        }
        
        [WebMethod]
        public DataSet1 FindBrandById(long id)
        {
            return Wrap(_brandLogic.FindByIdOrThrow(id));
        }
        
        [WebMethod]
        public DataSet1 AddBrand(string name)
        {
            return Wrap(_brandLogic.Add(name));
        }
        
                
        [WebMethod]
        public DataSet1 UpdateBrand(long id, string name)
        {
            return Wrap(_brandLogic.Update(id, name));
        }
        
        [WebMethod]
        public bool DeleteBrand(long id)
        {
            return _brandLogic.DeleteById(id);
        }
        
        /**
         * Model
         */
        [WebMethod]
        public DataSet1 GetAllModels()
        {
            return Wrap(_modelLogic.FindAllJoined());
        }
        
        [WebMethod]
        public DataSet1 FindModelById(long id)
        {
            return Wrap(_modelLogic.FindByIdOrThrowJoined(id));
        }
        
        [WebMethod]
        public DataSet1 AddModel(string name, long brandId)
        {
            return Wrap(_modelLogic.Add(name, brandId));
        }
        
        [WebMethod]
        public DataSet1 UpdateModel(long id, string name, long brandId)
        {
            return Wrap(_modelLogic.Update(id, name, brandId));
        }
        
        [WebMethod]
        public bool DeleteModel(long id)
        {
            return _modelLogic.DeleteById(id);
        }
        
        [WebMethod]
        public DataSet1 SearchModels(string brandId, string name)
        {
            return Wrap(_modelLogic.FindAllByAnyParam(name, brandId));
        }
        
        /**
         * Client
         */
        [WebMethod] public DataSet1 GetAllClients()
        {
            return Wrap(_clientLogic.FindAll());
        }
        
        [WebMethod]
        public DataSet1 FindClientById(long id)
        {
            return Wrap(_clientLogic.FindByIdOrThrow(id));
        }
        
        [WebMethod]
        public DataSet1 AddClient(string lastName, string name, string middleName, string phone)
        {
            return Wrap(_clientLogic.Add(lastName, name, middleName, phone));
        }
                
        [WebMethod]
        public DataSet1 UpdateClient(long id, string lastName, string name, string middleName, string phone)
        {
            return Wrap(_clientLogic.Update(id, lastName, name, middleName, phone));
        }

        [WebMethod]
        public DataSet1 SearchClients(string lastName, string name, string middleName, string phone)
        {
            return Wrap(_clientLogic.FindAllByAnyParam(lastName, name, middleName, phone));
        }
        
        [WebMethod]
        public bool DeleteClient(long id)
        {
            return _clientLogic.DeleteById(id);
        }
       
        /**
         * Worker
         */
        [WebMethod] public DataSet1 GetAllWorkers()
        {
            _workerLogic.FindAll();
            return _workerLogic.Cache;
        }
        
        [WebMethod]
        public DataSet1 FindWorkerById(long id)
        {
            return Wrap(_workerLogic.FindByIdOrThrow(id));
        }
        
        [WebMethod]
        public DataSet1 AddWorker(string lastName, string name, string middleName, string phone)
        {
            return Wrap(_workerLogic.Add(lastName, name, middleName, phone));
        }
        
        [WebMethod]
        public DataSet1 UpdateWorker(long id, string lastName, string name, string middleName, string phone)
        {
            return Wrap(_workerLogic.Update(id, lastName, name, middleName, phone));
        }
        
        [WebMethod]
        public bool DeleteWorker(long id)
        {
            return _workerLogic.DeleteById(id);
        }
        
        
        [WebMethod]
        public DataSet1 SearchWorkers(string lastName, string name, string middleName, string phone)
        {
            return Wrap(_workerLogic.FindAllByAnyParam(lastName, name, middleName, phone));
        }
        
        /**
         * Car
         */
        [WebMethod] public DataSet1 GetAllCars()
        {
            return Wrap(_carLogic.FindAllJoined());
        }
        
        [WebMethod]
        public DataSet1 FindCarById(long id)
        {
            return Wrap(_carLogic.FindByIdOrThrowJoined(id));
        }
        
        [WebMethod]
        public DataSet1 AddCar(string name, long modelId, long clientId)
        {
            return Wrap(_carLogic.Add(name, modelId, clientId));
        }
                
        [WebMethod]
        public DataSet1 UpdateCar(long id, string name, long modelId, long clientId)
        {
            return Wrap(_carLogic.Update(id, name, modelId, clientId));
        }

        [WebMethod]
        public bool DeleteCar(long id)
        {
            return _carLogic.DeleteById(id);
        }
        
        
        [WebMethod]
        public DataSet1 SearchCars(string name, string modelId, string clientId)
        {
            return Wrap(_carLogic.FindAllByAnyParam(name, modelId, clientId));
        }
        
        /**
         * Service
         */
        [WebMethod] public DataSet1 GetAllServices()
        {
            return Wrap(_serviceLogic.FindAllJoined());
        }
        
        [WebMethod]
        public DataSet1 FindServiceById(long id)
        {
            return Wrap(_serviceLogic.FindByIdOrThrowJoined(id));
        }
        
        [WebMethod]
        public DataSet1 AddService(string name, decimal amount, long carId, long typeId, long workerId)
        {
            return Wrap(_serviceLogic.Add(name, amount, carId, typeId, workerId));
        }
                
        [WebMethod]
        public DataSet1 UpdateService(long id, string name, decimal amount, long carId, long typeId, long workerId)
        {
            return Wrap(_serviceLogic.Update(id, name, amount, carId, typeId, workerId));
        }
        [WebMethod]
        public bool DeleteService(long id)
        {
            return _serviceLogic.DeleteById(id);
        }
        
        
        [WebMethod]
        public DataSet1 SearchServices(string name, string carId, string typeId, string workerId)
        {
            return Wrap(_serviceLogic.FindAllByAnyParam(name,carId,typeId, workerId));
        }
        
        private static DataSet1 Wrap<T>(ICollection<T> rows) where T : DataRow {
            var output = new DataSet1();
            foreach (var dataRow in rows)
            {
                output.Tables[dataRow.Table.TableName].ImportRow(dataRow);
            }
            return output;
        }

        
        private static DataSet1 Wrap(DataRow row) {
            var output = new DataSet1();
            output.Tables[row.Table.TableName].ImportRow(row);
            return output;
        }
    }
}
