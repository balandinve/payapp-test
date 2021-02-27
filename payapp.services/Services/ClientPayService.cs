using payapp.data;
using payapp.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace payapp.services.Services
{
    /// <summary>
    /// Управление счетом
    /// </summary>
    public interface IClientPayService
    {
        /// <summary>
        /// Операция по счету на сумму
        /// </summary>
        /// <param name="operationValue">сумма операции</param>
        /// <param name="operation">операция</param>
        void Movement(ClientOperation operation);
        /// <summary>
        /// Список операций клиента
        /// </summary>
        /// <param name="clientId">ИД клиента</param>
        /// <returns></returns>
        List<ClientOperation> GetClientOperations(Guid clientId);
        /// <summary>
        /// Операция клиента
        /// </summary>
        /// <param name="clientId">ИД клиента</param>
        /// <param name="operationId">ИД операции</param>
        /// <returns></returns>
        ClientOperation GetClientOperation(Guid clientId, Guid operationId);
    }
    /// <summary>
    /// Сервис управления счетом
    /// </summary>
    public class ClientPayService : IClientPayService
    {
        private AppDbContext context;

        public ClientPayService(AppDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// получить операцию клиента
        /// </summary>
        /// <param name="clientId">ИД клиента</param>
        /// <param name="operationId">ИД операции</param>
        /// <returns></returns>
        public ClientOperation GetClientOperation(Guid clientId, Guid operationId)
        {
            try
            {
                return context.ClientOperations.FirstOrDefault(x => x.ClientId == clientId && x.Id == operationId);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Список операций клиента
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public List<ClientOperation> GetClientOperations(Guid clientId)
        {
            try
            {
                return context.ClientOperations.Where(x => x.ClientId == clientId).ToList();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Операция по счету
        /// </summary>
        /// <param name="operationValue">сумма операции</param>
        /// <param name="operation">операция</param>
        public void Movement(ClientOperation operation)
        {
            try
            {
                context.ClientOperations.Add(operation);
            }
            catch
            {
                throw;
            }
        }
    }
}
