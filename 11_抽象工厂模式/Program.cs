using System;
using System.Configuration;
using System.Reflection;

namespace _11_抽象工厂模式
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    /// <summary>
    ///     产品1接口
    /// </summary>
    public interface IUser
    {
        void Insert(User user);
        User GetUser(int id);
    }

    /// <summary>
    ///     产品1分类A
    /// </summary>
    public class SqlserverUser : IUser
    {
        public void Insert(User user)
        {
            Console.WriteLine("在SQL Server中给User表增加一条记录");
        }

        public User GetUser(int id)
        {
            Console.WriteLine("在SQL Server中根据ID得到User表一条记录");
            return null;
        }
    }

    /// <summary>
    ///     产品1分类B
    /// </summary>
    public class AccessUser : IUser
    {
        public void Insert(User user)
        {
            Console.WriteLine("在Access中给User表增加一条记录");
        }

        public User GetUser(int id)
        {
            Console.WriteLine("在Access中根据ID得到User表一条记录");
            return null;
        }
    }


    public class Department
    {
        public int Id { get; set; }

        public string DeptName { get; set; }
    }

    /// <summary>
    ///     产品2接口
    /// </summary>
    public interface IDepartment
    {
        void Insert(Department department);
        Department GetDepartment(int id);
    }

    /// <summary>
    ///     产品2分类A
    /// </summary>
    public class SqlserverDepartment : IDepartment
    {
        public void Insert(Department department)
        {
            Console.WriteLine("在SQL Server中给Department表增加一条记录");
        }

        public Department GetDepartment(int id)
        {
            Console.WriteLine("在SQL Server中根据ID得到Department表一条记录");
            return null;
        }
    }

    /// <summary>
    ///     产品2分类B
    /// </summary>
    public class AccessDepartment : IDepartment
    {
        public void Insert(Department department)
        {
            Console.WriteLine("在Access中给Department表增加一条记录");
        }

        public Department GetDepartment(int id)
        {
            Console.WriteLine("在Access中根据ID得到Department表一条记录");
            return null;
        }
    }

    ///// <summary>
    /////     工厂接口 通过接口选择用哪一个分类的工厂
    ///// </summary>
    //private interface IFactory
    //{
    //    // 把工厂部分改成简单工厂可以解决增删分类修改多的问题
    //    // 同时也可以做到生产多种分类产品
    //    // 只要产品类有做好抽象
    //    IUser CreateUser();
    //    IDepartment CreaterDepartment();
    //}

    ///// <summary>
    /////     分类A工厂 带该分类下的产品生产方法
    ///// </summary>
    //private class SqlServerFactory : IFactory
    //{
    //    public IUser CreateUser()
    //    {
    //        //IUser result= (IUser)Assembly.Load("")


    //        return null;
    //    }

    //    public IDepartment CreaterDepartment()
    //    {
    //        return new SqlserverDepartment();
    //    }
    //}

    ///// <summary>
    /////     分类B工厂 带该分类下的产品生产方法
    ///// </summary>
    //private class AccessFactory : IFactory
    //{
    //    public IUser CreateUser()
    //    {
    //        return new AccessUser();
    //    }

    //    public IDepartment CreaterDepartment()
    //    {
    //        return new AccessDepartment();
    //    }
    //}


    ///// <summary>
    /////     简单工厂实现
    ///// </summary>
    //class DataAccess
    //{
    //    private static readonly string db = "Sqlserver";
    //    //private static readonly string db = "Access";
    //    public static IUser CreateUser()
    //    {
    //        IUser result = null;
    //        switch (db)
    //        {
    //            case "Sqlserver":
    //                result=new SqlserverUser();
    //                break;
    //            case "Access":
    //                result=new AccessUser();
    //                break;
    //        }

    //        return result;
    //    }

    //    public static IDepartment CreateDepartment()
    //    {
    //        IDepartment result = null;
    //        switch (db)
    //        {
    //            case "Sqlserver":
    //                result = new SqlserverDepartment();
    //                break;
    //            case "Access":
    //                result = new AccessDepartment();
    //                break;
    //        }

    //        return result;
    //    }
    //}

    /// <summary>
    ///     反射+配置文件实现
    /// </summary>
    internal class DataAccess
    {
        // 程序集名称 项目右键属性查看
        private static readonly string AssemblyName = "抽象工厂模式";

        // 产品类名的不同部分
        // 通过配置文件读取   ConfigurationManager需要引用System.Configuration 读取自带的App.config
        // 也可以使用Json、ini等读取
        private static readonly string db = ConfigurationManager.AppSettings["DB"];

        public static IUser CreateUser()
        {
            // 产品类名 命名空间名+“.”+类名
            // Assembly.Load(程序集名称).CreateInstance(要实例出来的类名);
            var className = "_11_抽象工厂模式." + db + "User";
            return (IUser)Assembly.Load(AssemblyName).CreateInstance(className);
        }

        public static IDepartment CreateDepartment()
        {
            var className = "_11_抽象工厂模式." + db + "Department";
            return (IDepartment)Assembly.Load(AssemblyName).CreateInstance(className);
        }
    }

    internal class Program
    {
        /// <summary>
        ///     使用
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            var user = new User();
            var dept = new Department();

            var iu = DataAccess.CreateUser();

            iu.Insert(user);
            iu.GetUser(1);

            var id = DataAccess.CreateDepartment();
            id.Insert(dept);
            id.GetDepartment(1);

            Console.ReadKey();
        }
    }
}