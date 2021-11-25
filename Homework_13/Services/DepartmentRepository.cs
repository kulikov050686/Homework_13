using Homework_13.Interfaces;
using Homework_13.Models;
using System.Linq;

namespace Homework_13.Services
{
    /// <summary>
    /// Хранилище департаментов банка
    /// </summary>
    public class DepartmentRepository : RepositoryInMemory<IDepartment>
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public DepartmentRepository() : base(TestData.Departments) { }

        /// <summary>
        /// Поиск департамента по имени
        /// </summary>
        /// <param name="nameDepartment"> Имя департамента </param>
        public IDepartment Get(string nameDepartment)
        {
            return GetAll().FirstOrDefault(d => d.Name == nameDepartment);
        }
        
        /// <summary>
        /// Обновление данных департамента банка
        /// </summary>
        /// <param name="source"> Новые данные департамента </param>
        /// <param name="destination"> Обновляемый департамент </param>
        protected override void Update(IDepartment source, IDepartment destination)
        {
            destination.BankCustomers = source.BankCustomers;
            destination.Id = source.Id;
            destination.Name = source.Name;
        }
    }
}
