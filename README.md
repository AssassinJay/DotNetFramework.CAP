# DotNetFramework.CAP
DotNetFramework.CAP ��һ������ .NET Framework�� C# �⣬����һ�ִ���ֲ�ʽ����Ľ������,����DotNetCore.CAP�޸ġ�

##1. �˴����ǻ���DotCore.CAP 2.5.1 �汾�޸�.

##2. DotNetFramework.CAP ����Core�ļ�����Ҫʵ�� DotNetCore�µ�Ioc����. ��־Logger.

    ###a.  ʹ�� AutoFac ʵ�� ServiceProvider,ServiceCollection,ServiceScope,ActivatorUtilities.
  
    ###b.  ʹ�� Serilog ʵ�� Core�µ�Logger.
  
  
##3. �ڲ������޸����£�

    ###a. ɾ��DashBoard.��ʱû��ʵ�֡�
  
    ###b. ���������޸ġ�
    ./App_Srart
    
    public class CapConfig
    {
        public static IServiceCollection Services { get; set; }

        public static void RegisterCap()
        {
            Services = new ServiceCollection();
            Services.AddCap(stetup =>
            {
                // ע��ڵ㵽 Consul
                stetup.UseSqlServer("Data Source=localhost;database=donet61;Uid=sa;pwd=sa;");
                stetup.UseRabbitMQ(option =>
                {
                    option.VirtualHost = "HengQueue";
                    option.HostName = "localhost";
                    option.Port = 5672;
                    option.UserName = "zhangheng";
                    option.Password = "123456";
                });
            });
            Services.BeginRegister();
            Services.ServiceProvider.GetService<IBootstrapper>().BootstrapAsync(new CancellationToken());
        }
    }
    protected void Application_Start()
    {
        CapConfig.RegisterCap();
    }
    
    ###c.  ��ȡcontroller�¶��ķ����޸ġ�
     ����������.net core asp.net �� framework asp.net��web���Ʊ仯��
            //heng
            //var types = Assembly.GetEntryAssembly().ExportedTypes;
            var types = BuildManager.GetGlobalAsaxType().BaseType.Assembly.ExportedTypes;
    ###d. Dapperִ��Sql �����첽ִ�и�Ϊͬ������Ϊ������frameworkwork�»Ῠ����
     connection.Execute(sql);
     
    ###e. Sqlserverִ�в����ķ�����Ϣʱ���ĸĶ���
    ###f. EntityFrameworkִ�в����ķ�����Ϣʱ���ĸĶ���
    
    Diagnostic.DiagnosticSource
    ����ԭ���ߣ�DoNetCoreCAP����Core��Sqlserver��Diagnostic����ɵĹ۲�ʱ�����з�����Ϣ����
    Ȼ����framework�µ�Sqlserver Client����û��ʵ��Diagnostic�Ŀɹ۲���Ϊ��  ��
    
    ��չcommit����ʵʱ��Ϣ���ͣ�  
    
    �޸�Ϊ��   public static void Commit(this IDbTransaction trans, ICapPublisher bus)
              {
                  bus.Transaction.Commit();
              }
              public static void Commit(this DbContextTransaction trans, ICapPublisher bus)
              {
                  bus.Transaction.Commit();
              }    
              
              �ύ����ʹ�����´��룺   
              transaction.Commit(_capBus);   ����������Ӵ���CapWeb251 
              
        

   

   
   
   
   

   
    

   
   
              
    
            
            
            
