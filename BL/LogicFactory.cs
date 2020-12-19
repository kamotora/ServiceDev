namespace BL
{
    public class LogicFactory
    {
        private static  BrandLogic _brandLogic;
        public static BrandLogic BrandLogic => _brandLogic ?? (_brandLogic = new BrandLogic());

        private static  ModelLogic _modelLogic;
        public  static ModelLogic ModelLogic => _modelLogic ?? (_modelLogic = new ModelLogic());

        private static  ClientLogic _clientLogic;
        public  static ClientLogic ClientLogic => _clientLogic ?? (_clientLogic = new ClientLogic());

        private static  WorkerLogic _workerLogic;
        public  static WorkerLogic WorkerLogic => _workerLogic ?? (_workerLogic = new WorkerLogic());

        private  static ServiceLogic _serviceLogic;
        public  static ServiceLogic ServiceLogic => _serviceLogic ?? (_serviceLogic = new ServiceLogic());

        private static  TypeServiceLogic _typeServiceLogic;
        public  static TypeServiceLogic TypeServiceLogic => _typeServiceLogic ?? (_typeServiceLogic = new TypeServiceLogic());
        
        private static  CarLogic _carLogic;
        public  static CarLogic CarLogic => _carLogic ?? (_carLogic = new CarLogic());
    }
}