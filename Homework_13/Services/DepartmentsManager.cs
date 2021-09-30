using Homework_13.Interfaces;
using System.Collections.Generic;

namespace Homework_13.Services
{
    /// <summary>
    /// Менеджер отдела банка
    /// </summary>
    public class DepartmentsManager
    {
        #region Закрытые поля

        private DepartmentRepository _departmentRepository;

        #endregion

        /// <summary>
        /// Cписок всех департаментов
        /// </summary>
        public IList<IDepartment> Departments => _departmentRepository.GetAll();

        /// <summary>
        /// Получить департамент по имени
        /// </summary>
        /// <param name="name"> Имя департамента </param>
        public IDepartment Get(string name) => _departmentRepository.Get(name);

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="departmentRepository"> Хранилище департаментов банка </param>
        public DepartmentsManager(DepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
    }
}
