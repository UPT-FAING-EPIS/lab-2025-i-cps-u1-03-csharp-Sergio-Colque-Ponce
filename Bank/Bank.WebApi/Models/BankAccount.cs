namespace Bank.WebApi.Models
{
    /// <summary>
    /// Representa una cuenta bancaria con funcionalidades básicas de débito y crédito.
    /// Permite gestionar el balance de un cliente específico.
    /// </summary>
    /// <remarks>
    /// Esta clase implementa las operaciones fundamentales de una cuenta bancaria,
    /// incluyendo validaciones para prevenir operaciones inválidas como débitos
    /// que excedan el balance o montos negativos.
    /// </remarks>
    public class BankAccount
    {
        /// <summary>
        /// Nombre del cliente propietario de la cuenta. Campo de solo lectura.
        /// </summary>
        private readonly string m_customerName = string.Empty;
        
        /// <summary>
        /// Balance actual de la cuenta bancaria.
        /// </summary>
        private double m_balance;
        
        /// <summary>
        /// Constructor privado para prevenir la creación de instancias sin parámetros.
        /// </summary>
        private BankAccount() { }
        
        /// <summary>
        /// Inicializa una nueva instancia de la clase BankAccount.
        /// </summary>
        /// <param name="customerName">El nombre del cliente propietario de la cuenta.</param>
        /// <param name="balance">El balance inicial de la cuenta.</param>
        /// <exception cref="ArgumentNullException">Se lanza cuando customerName es null.</exception>
        /// <exception cref="ArgumentException">Se lanza cuando customerName está vacío.</exception>
        /// <example>
        /// <code>
        /// var account = new BankAccount("Juan Pérez", 1000.0);
        /// </code>
        /// </example>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }
        
        /// <summary>
        /// Obtiene el nombre del cliente propietario de la cuenta.
        /// </summary>
        /// <value>El nombre del cliente como una cadena de texto.</value>
        public string CustomerName { get { return m_customerName; } }
        
        /// <summary>
        /// Obtiene el balance actual de la cuenta.
        /// </summary>
        /// <value>El balance actual como un número de punto flotante.</value>
        public double Balance { get { return m_balance; }  }
        
        /// <summary>
        /// Debita (retira) una cantidad específica del balance de la cuenta.
        /// </summary>
        /// <param name="amount">La cantidad a debitar de la cuenta.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Se lanza cuando:
        /// - El monto es mayor que el balance actual
        /// - El monto es negativo
        /// </exception>
        /// <example>
        /// <code>
        /// var account = new BankAccount("Juan Pérez", 1000.0);
        /// account.Debit(250.0); // Balance resultante: 750.0
        /// </code>
        /// </example>
        public void Debit(double amount)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThan(amount, m_balance);
            ArgumentOutOfRangeException.ThrowIfNegative(amount);
            m_balance -= amount;
        }

        /// <summary>
        /// Acredita (deposita) una cantidad específica al balance de la cuenta.
        /// </summary>
        /// <param name="amount">La cantidad a acreditar a la cuenta.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Se lanza cuando el monto es negativo.
        /// </exception>
        /// <example>
        /// <code>
        /// var account = new BankAccount("Juan Pérez", 1000.0);
        /// account.Credit(500.0); // Balance resultante: 1500.0
        /// </code>
        /// </example>
        public void Credit(double amount)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(amount);
            m_balance += amount;
        }
    }
}