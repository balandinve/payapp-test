using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace payapp.data.Models
{
    /// <summary>
    /// Операция клиента со счетом
    /// </summary>
    [Table("client_operations")]
    public class ClientOperation
    {
        /// <summary>
        /// ИД операции
        /// </summary>
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        /// <summary>
        /// ИД клиента
        /// </summary>
        [Column("client_id")]
        public Guid ClientId { get; set; }
        /// <summary>
        /// Тип операции
        /// </summary>
        [Column("operation_type")]
        public CLIENT_OPERATION OperationType { get; set; }
        /// <summary>
        /// Сумма операции
        /// </summary>
        [Column("operation_value")]
        public decimal OperationValue { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        public ClientOperation()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
