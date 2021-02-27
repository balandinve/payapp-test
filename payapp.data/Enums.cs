using System;
using System.Collections.Generic;
using System.Text;

namespace payapp.data
{
    /// <summary>
    /// операции клиента со счетом
    /// </summary>
    public enum CLIENT_OPERATION
    {
        /// <summary>
        /// снять деньги
        /// </summary>
        WITHDRAW = 1,
        /// <summary>
        /// пополнить счет
        /// </summary>
        DEPOSITE = 2
    }
}
